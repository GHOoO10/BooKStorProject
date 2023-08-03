using GhamdanAlYamaniProject.Data;
using GhamdanAlYamaniProject.Models.Interface;

namespace GhamdanAlYamaniProject.Models.Repositroy
{
    public class CustomerRepositroy : IBaseRepository<Customer>
    {
        private readonly ProjectDbContext _context;
        public CustomerRepositroy(ProjectDbContext ctx)
        {
            _context = ctx;
        }
        public void Add(Customer item)
        {
            _context.Customers.Add(item);
            _context.SaveChanges();
        }

        public void Delete(Customer item)
        {
            _context.Customers.Remove(item);
            _context.SaveChanges();
        }

        public Customer Find(int Id) => _context.Customers.Find(Id);

        public IEnumerable<Customer> GetAll() => _context.Customers;

        public void Update(Customer item)
        {
            _context.Customers.Update(item);
            _context.SaveChanges();
        }
    }
}
