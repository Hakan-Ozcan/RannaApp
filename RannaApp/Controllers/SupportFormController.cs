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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SupportForm supportForm)
        {
            if (ModelState.IsValid)
            {
                // Burada supportForm parametresiyle gelen verileri kullanarak güncelleme işlemini yapabilirsiniz.
                // Örneğin:
                //_supportFormService.UpdateSupportFormStatus(supportForm);
                return RedirectToAction("Index");
            }
            return View(supportForm); // Doğrulama hatası varsa, formu tekrar göster
        }
        public IActionResult Edit(int id)
        {
            // Belirli bir formun bilgilerini al
            var supportForm = _supportFormService.GetSupportForm(id);

            // Form bulunamazsa hata sayfasına yönlendir
            if (supportForm == null)
            {
                return NotFound();
            }

            // Düzenleme sayfasını göster
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
    }
}

