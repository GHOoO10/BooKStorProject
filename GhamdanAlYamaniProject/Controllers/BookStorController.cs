using GhamdanAlYamaniProject.Data;
using GhamdanAlYamaniProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GhamdanAlYamaniProject.Controllers
{
    public class BookStorController : Controller
    {
        private readonly ProjectDbContext _context;
        public BookStorController(ProjectDbContext ctx)
        {
            _context = ctx;
        }
        public IActionResult Index()
        {
            ViewBag.catagory = _context.Catagorys;
            return View();
        }
        public IActionResult Create()
        {
            ViewBag.catagory = _context.Catagorys;
            return View();
        }
        [HttpPost]
        public IActionResult Create(BookStor bookstor)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.catagory = _context.Catagorys;
                return View(bookstor);
            }
            if (bookstor.BS_Type == 1)
            {
                bookstor.BS_Num *= -1;
            }
            _context.BookStors.Add(bookstor);
            _context.SaveChanges();
             
            return RedirectToAction("Index","Books");
        }

        public JsonResult LoadBookByCat(int Id)
        {
            var book = _context.Book.Where(p => p.Cat_Id == Id);
            return Json(new SelectList(book, "B_Id", "B_Name"));
        }
    }
}
