using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyVet.commond.Models;
using MyVet.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.Controllers.API
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OwnersController:ControllerBase
    {
        private readonly DataContext _dataContext;

        public OwnersController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost]
        [Route("GetOwnerByEmail")]
        public async Task<IActionResult> GetOwner(EmailRequest emailRequest) 
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var owner = await _dataContext.Owners
                .Include(o => o.User)
                .Include(o => o.Pets)
                .ThenInclude(p => p.PetType)
                .Include(o => o.Pets)
                .ThenInclude(p => p.Histories)
                .ThenInclude(h => h.ServiceType)
                .FirstOrDefaultAsync(o => o.User.UserName.ToLower()==(emailRequest.Email.ToLower()));

            var response = new OwnerResponse
            {
                OwnerResponseId=owner.OwnerId,
                FirstName = owner.User.FirstName,
                LastName = owner.User.LastName,
                Address = owner.User.Address,
                Document = owner.User.Document,
                Email = owner.User.Email,
                PhoneNumber = owner.User.PhoneNumber,
                Pets = owner.Pets.Select(p => new PetResponse
                {
                    Born = p.Born,
                    PetResponseId = p.PetId,
                    ImageUrl = p.ImageFullPath,
                    Name = p.Name,
                    Race = p.Race,
                    Remarks = p.Remarks,
                    PetType = p.PetType.Name,
                    Histories = p.Histories.Select(h => new HistoryResponse
                    {
                        Date = h.Date,
                        Description = h.Description,
                        HistoryResponseId = h.HistoryId,
                        Remarks = h.Remarks,
                        ServiceType = h.ServiceType.Name
                    }).ToList()
                }).ToList()
            };

            return Ok(response);
        }
    }

}

//Todo: 58 part28 (https://www.youtube.com/watch?v=JjMWh7FXphc&list=PLuEZQoW9bRnQrpKPFrvDjazXOCEAkLrK8&index=28)