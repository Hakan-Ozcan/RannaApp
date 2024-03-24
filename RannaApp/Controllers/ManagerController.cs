using BusinessLayer.Abstract;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;


namespace YourNamespace.Controllers
{
    public class ManagerController : Controller
    {
        private readonly IManagerService _managerService;

        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        public IActionResult Index()
        {
            var managers = _managerService.GetManagers();
            return View(managers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Manager manager)
        {
            if (ModelState.IsValid)
            {
                _managerService.ManagerAdd(manager);
                return RedirectToAction("Index");
            }
            return View(manager);
        }

        public IActionResult Edit(int id)
        {
            //            var manager = _managerService.GetManagers().Find(m => m.Name == id
            //);
            //            if (manager == null)
            //            {
            //                return NotFound();
            //            }
            //            return View(manager);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Manager manager)
        {
            if (ModelState.IsValid)
            {
                _managerService.ManagerUpdate(manager);
                return RedirectToAction("Index");
            }
            return View(manager);
        }

        public IActionResult Delete(int id)
        {
            //var manager = _managerService.GetManagers().Find(m => m.Id == id);
            //if (manager == null)
            //{
            //    return NotFound();
            //}
            //return View(manager);
            return View();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _managerService.ManagerDelete(id);
            return RedirectToAction("Index");
        }
    }
}

