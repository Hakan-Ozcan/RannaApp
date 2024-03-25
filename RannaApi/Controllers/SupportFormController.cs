using BusinessLayer.Abstract;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RannaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportFormController : ControllerBase
    {
        private readonly ISupportFormService _supportFormService;

        public SupportFormController(ISupportFormService supportFormService)
        {
            _supportFormService = supportFormService;
        }

        [HttpPost]
        [Authorize] 
        public IActionResult PostSupportForm([FromBody] SupportFormDto supportFormDto)
        {
            try
            {
       
                var supportForm = new SupportForm
                {
                    User = supportFormDto.User,
                    Subject = supportFormDto.Subject,
                    Message = supportFormDto.Message,
                    Date = DateTime.Now,
                    FormStatus = "New" 
                };

         
                _supportFormService.SupportFormAdd(supportForm);

             
                return Ok(new { success = true, supportFormId = supportForm.Id });
            }
            catch (Exception ex)
            {
           
                return StatusCode(500, new { success = false, error = ex.Message });
            }
        }
    }


   
}
