using GhamdanAlYamaniProject.Models;
using GhamdanAlYamaniProject.Models.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GhamdanAlYamaniProject.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBaseRepository<Books> _repo;
        private readonly IBaseRepository<Catagory> _catRepo;
        private readonly IBaseRepository<Admin> _adminRepo;
        
        public BooksController(IBaseRepository<Books> repository,
            IBaseRepository<Catagory> catRepo,
            IBaseRepository<Admin> adminRepo)
        {
            _repo = repository;
            _catRepo = catRepo;
            _adminRepo = adminRepo;
        }
        public IActionResult Index()
        {
            var books = _repo.GetAll();
            return View(books);
        }

        public IActionResult Details(int Id)
        {
            var book = _repo.Find(Id);
            return View(book);
        }

        public IActionResult Create()
        {
            ViewBag.catagory = _catRepo.GetAll();
            ViewBag.admin = _adminRepo.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Books books)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.catagory = _catRepo.GetAll();
                ViewBag.admin = _adminRepo.GetAll();
                return View(books);
            }
            _repo.Add(books);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int Id)
        {
            ViewBag.catagory = _catRepo.GetAll();
            ViewBag.admin = _adminRepo.GetAll();
            var books = _repo.Find(Id);
            return View(books);
        }
        [HttpPost]
        public IActionResult Edit(Books books)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.catagory = _catRepo.GetAll();
                ViewBag.admin = _adminRepo.GetAll();
                return View(books);
            }
            _repo.Update(books);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int Id)
        {
            ViewBag.catagory = _catRepo.GetAll();
            ViewBag.admin = _adminRepo.GetAll();
            var books = _repo.Find(Id);
            return View(books);
        }

        [HttpPost]
        public IActionResult Delete(Books books)
        {
            _repo.Delete(books);
            return RedirectToAction(nameof(Index));
        }
    }
}
