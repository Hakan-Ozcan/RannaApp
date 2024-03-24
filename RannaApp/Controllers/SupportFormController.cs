using Microsoft.AspNetCore.Mvc;
using EntityLayer.Entities;
using BusinessLayer.Abstract;
using System.Collections.Generic;

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

        public IActionResult Edit(int id)
        {
            // Burada düzenleme sayfasını oluşturmak için gerekli işlemleri yapabilirsiniz.
            return RedirectToAction("Index"); // Örnek amaçlı Index sayfasına yönlendirme yapıldı.
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
    }
}

