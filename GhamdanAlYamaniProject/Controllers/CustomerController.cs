using GhamdanAlYamaniProject.Models;
using GhamdanAlYamaniProject.Models.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GhamdanAlYamaniProject.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IBaseRepository<Customer> _repo;
        public CustomerController(IBaseRepository<Customer> repository)
        {
            _repo = repository;
        }
        public IActionResult Index()
        {
            var customer = _repo.GetAll();
            return View(customer);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {

                /*if (customer.C_Phone != null)
                {
                    ModelState.AddModelError("C_Phone", "dpfkldjfk");
                    return View(customer);
                }*/

                _repo.Add(customer);
                return RedirectToAction("Index");
            }

            return View(customer);
        }
        public IActionResult Edit(int Id)
        {
            var customer = _repo.Find(Id);
            return View(customer);
        }
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(customer);
                return RedirectToAction("Index");
            }

            return View(customer);
        }
        public IActionResult Delete(int Id)
        {
            var customer = _repo.Find(Id);
            return View(customer);
        }
        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            _repo.Delete(customer);
            return RedirectToAction("index");
        }
    }
}
