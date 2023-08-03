using GhamdanAlYamaniProject.Models;
using GhamdanAlYamaniProject.Models.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GhamdanAlYamaniProject.Controllers
{
    public class CatagoryController : Controller
    {
        private readonly IBaseRepository<Catagory> _repo;
        public CatagoryController(IBaseRepository<Catagory> repository)
        {
            _repo = repository;
        }
        public IActionResult Index()
        {
            var catagory = _repo.GetAll();
            return View(catagory);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Catagory catagory)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(catagory);
                return RedirectToAction("Index");
            }

            return View(catagory);
        }
        public IActionResult Edit(int Id)
        {
            var catagory = _repo.Find(Id);
            return View(catagory);
        }
        [HttpPost]
        public IActionResult Edit(Catagory catagory)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(catagory);
                return RedirectToAction("Index");
            }

            return View(catagory);
        }
        public IActionResult Delete(int Id)
        {
            var catagory = _repo.Find(Id);
            return View(catagory);
        }
        [HttpPost]
        public IActionResult Delete(Catagory catagory)
        {
            _repo.Delete(catagory);
            return RedirectToAction("index");
        }
    }
}
