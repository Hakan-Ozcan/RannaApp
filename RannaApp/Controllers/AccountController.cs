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
        private readonly IConfiguration _configuration;
        public AccountController(ICustomerService customerService, IConfiguration configuration)
        {
            _customerService = customerService;
            _configuration = configuration;
        }
        public Customer GetCustomerByUsernameAndPassword(string username, string password)
        {
            return _customerService.GetCustomers()
                                      .SingleOrDefault(c => c.username == username && c.password == password);
        }

        public ActionResult Login()
        {
            return View();
        }

 
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
               
                    return RedirectToAction("Index", "Home");
                }
                else
                {
            
                    ModelState.AddModelError(string.Empty, "Geçersiz kullanıcı adı veya parola.");
                }
            }

      
            return View(model);
        }

    }
}
