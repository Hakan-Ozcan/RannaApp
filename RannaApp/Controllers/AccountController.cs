using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using RannaApi.Controllers;

namespace RannaUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICustomerService _customerService;

        public AccountController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public Customer GetCustomerByUsernameAndPassword(string username, string password)
        {
            return _customerService.GetCustomers()
                                      .SingleOrDefault(c => c.username == username && c.password == password);
        }
        // GET: /Account/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var authenticationController = new AuthenticationController(_customerService);
                var loginResponse = await authenticationController.LoginAsync(model.UserName, model.Password);

                if (loginResponse.result)
                {
                    // Başarılı giriş
                    // Token veya diğer bilgileri kullanabilirsiniz
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Geçersiz kullanıcı adı veya parola
                    ModelState.AddModelError(string.Empty, "Geçersiz kullanıcı adı veya parola.");
                }
            }

            // ModelState geçerli değilse, tekrar login sayfasını gösterin.
            return View(model);
        }

    }
}
