using GhamdanAlYamaniProject.Data;
using GhamdanAlYamaniProject.Models.Interface;
using Microsoft.EntityFrameworkCore;

namespace GhamdanAlYamaniProject.Models.Repositroy
{
    public class OrdersRepositroy : IBaseRepository<Orders>
    {
        private readonly ProjectDbContext _context;
        public OrdersRepositroy(ProjectDbContext ctx)
        {
            _context = ctx;
        }
        public void Add(Orders item)
        {
            _context.Order.Add(item);
            _context.SaveChanges();
        }

        public void Delete(Orders item)
        {
            _context.Order.Remove(item);
            _context.SaveChanges();
        }

        public Orders Find(int Id) =>
            _context.Order
                 .Include(o => o.Book).Include(o => o.Customers).FirstOrDefault(o => o.O_Id == Id);

        public IEnumerable<Orders> GetAll() => _context.Order.Include(o => o.Book).Include(o => o.Customers);

        public void Update(Orders item)
        {
            _context.Order.Update(item);
            _context.SaveChanges();
        }
    }
}
