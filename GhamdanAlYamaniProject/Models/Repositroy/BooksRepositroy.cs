using GhamdanAlYamaniProject.Data;
using GhamdanAlYamaniProject.Models.Interface;
using Microsoft.EntityFrameworkCore;

namespace GhamdanAlYamaniProject.Models.Repositroy
{
    public class BooksRepositroy : IBaseRepository<Books>
    {
        private readonly ProjectDbContext _context;
        public BooksRepositroy(ProjectDbContext ctx)
        {
            _context = ctx;
        }
        public void Add(Books item)
        {
            _context.Book.Add(item);
            _context.SaveChanges();
        }

        public void Delete(Books item)
        {
            _context.Book.Remove(item);
            _context.SaveChanges();
        }

        public Books Find(int Id) => 
            _context.Book
                 .Include(b => b.Catagorys).Include(b => b.Admins)
                 .Include(b => b.BookStors).FirstOrDefault(b => b.B_Id == Id);

        public IEnumerable<Books> GetAll() =>
            _context.Book.Include(b => b.Catagorys).Include(b => b.Admins).Include(p => p.BookStors);

        public void Update(Books item)
        {
            _context.Book.Update(item);
            _context.SaveChanges();
        }
    }
}
