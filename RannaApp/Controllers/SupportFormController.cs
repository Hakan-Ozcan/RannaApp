using Microsoft.AspNetCore.Mvc;
using EntityLayer.Entities;
using BusinessLayer.Abstract;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using RannaApi.Controllers;

namespace YourNamespace.Controllers
{
    public class SupportFormController : Controller
    {
        private readonly ISupportFormService _supportFormService;

        public SupportFormController(ISupportFormService supportFormService)
        {
            _supportFormService = supportFormService;
        }

        public IActionResult Index()
        {
            List<SupportForm> supportForms = _supportFormService.GetSupportForms();
            return View(supportForms);
        }

        [HttpPost]
        public IActionResult UpdateStatus(int id, string status)
        {
            _supportFormService.UpdateSupportFormStatus(id, status);
            return Ok();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SupportForm supportForm)
        {
            if (ModelState.IsValid)
            {
             
                return RedirectToAction("Index");
            }
            return View(supportForm);
        }
        public IActionResult Edit(int id)
        {
     
            var supportForm = _supportFormService.GetSupportForm(id);

       
            if (supportForm == null)
            {
                return NotFound();
            }

     
            return View(supportForm);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SupportForm supportForm)
        {
            if (ModelState.IsValid)
            {
                _supportFormService.SupportFormAdd(supportForm);
                return RedirectToAction("Index");
            }
            return View(supportForm);
        }
      
        [HttpPost]
        [Route("api/SupportForm/Create")]
        [Authorize] 
        public async Task<IActionResult> CreateApi([FromBody] SupportFormDto supportFormDto)
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

