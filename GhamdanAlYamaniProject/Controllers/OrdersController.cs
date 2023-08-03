using GhamdanAlYamaniProject.Models;
using GhamdanAlYamaniProject.Models.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GhamdanAlYamaniProject.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IBaseRepository<Orders> _repo;
        private readonly IBaseRepository<Books> _bookRepo;
        private readonly IBaseRepository<Customer> _customerRepo;

        public OrdersController(IBaseRepository<Orders> repository,
            IBaseRepository<Books> bookRepo,
            IBaseRepository<Customer> customerRepo)
        {
            _repo = repository;
            _bookRepo = bookRepo;
            _customerRepo = customerRepo;
        }
        public IActionResult Index()
        {
            var orders = _repo.GetAll();
            return View(orders);
        }

        public IActionResult Details(int Id)
        {
            var orders = _repo.Find(Id);
            return View(orders);
        }
        public IActionResult Create()
        {
            ViewBag.book = _bookRepo.GetAll();
            ViewBag.customer = _customerRepo.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Orders orders)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.book = _bookRepo.GetAll();
                ViewBag.customer = _customerRepo.GetAll();
                return View(orders);
            }
            _repo.Add(orders);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int Id)
        {
            ViewBag.book = _bookRepo.GetAll();
            ViewBag.customer = _customerRepo.GetAll();
            var orders = _repo.Find(Id);
            return View(orders);
        }
        [HttpPost]
        public IActionResult Edit(Orders orders)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.book = _bookRepo.GetAll();
                ViewBag.customer = _customerRepo.GetAll();
                return View(orders);
            }
            _repo.Update(orders);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int Id)
        {
            ViewBag.book = _bookRepo.GetAll();
            ViewBag.customer = _customerRepo.GetAll();
            var orders = _repo.Find(Id);
            return View(orders);
        }

        [HttpPost]
        public IActionResult Delete(Orders orders)
        {
            _repo.Delete(orders);
            return RedirectToAction(nameof(Index));
        }
    }
}
