using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Burada login işlemini gerçekleştirin, örneğin, veritabanında kullanıcı adı ve parolayı kontrol edin.

                // Başarılı bir login durumunda yönlendirme yapabilirsiniz.
                //return RedirectToAction("Index", "Home");

                // Kullanıcı adı ve parolayı kullanarak ilgili kullanıcıyı bul
                var customer = GetCustomerByUsernameAndPassword(model.UserName, model.Password);

                // Kullanıcı varsa ve parola doğruysa
                if (customer != null)
                {
                    // Giriş yapılabilir, örneğin ana sayfaya yönlendirme yapılabilir
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Kullanıcı adı veya parola hatalı ise hata mesajı gösterilebilir
                    ModelState.AddModelError(string.Empty, "Geçersiz kullanıcı adı veya parola.");
                }
            }

            // ModelState geçerli değilse, tekrar login sayfasını gösterin.
            return View(model);
        }
    }
}
