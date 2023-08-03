using GhamdanAlYamaniProject.Models;
using GhamdanAlYamaniProject.Models.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GhamdanAlYamaniProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly IBaseRepository<Admin> _repo;
        public AdminController(IBaseRepository<Admin> repository)
        {
            _repo = repository;
        }
        public IActionResult Index()
        {
            var admin = _repo.GetAll();
            return View(admin);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Admin admin)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(admin);
                return RedirectToAction("Index");
            }

            return View(admin);
        }
        public IActionResult Edit(int Id)
        {
            var admin = _repo.Find(Id);
            return View(admin);
        }
        [HttpPost]
        public IActionResult Edit(Admin admin)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(admin);
                return RedirectToAction("Index");
            }

            return View(admin);
        }
        public IActionResult Delete(int Id)
        {
            var admin = _repo.Find(Id);
            return View(admin);
        }
        [HttpPost]
        public IActionResult Delete(Admin admin)
        {
            _repo.Delete(admin);
            return RedirectToAction("index");
        }
    }
}
