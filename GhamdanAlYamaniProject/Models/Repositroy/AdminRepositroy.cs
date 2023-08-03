using GhamdanAlYamaniProject.Data;
using GhamdanAlYamaniProject.Models.Interface;

namespace GhamdanAlYamaniProject.Models.Repositroy
{
    public class AdminRepositroy : IBaseRepository<Admin>
    {
        private readonly ProjectDbContext _context;
        public AdminRepositroy(ProjectDbContext ctx)
        {
            _context = ctx;
        }
        public void Add(Admin item)
        {
            _context.Admins.Add(item);
            _context.SaveChanges(); 
        }

        public void Delete(Admin item)
        {
            _context.Admins.Remove(item);
            _context.SaveChanges();
        }

        public Admin Find(int Id) => _context.Admins.Find(Id);

        public IEnumerable<Admin> GetAll() => _context.Admins;

        public void Update(Admin item)
        {
            _context.Admins.Update(item);
            _context.SaveChanges();
        }
    }
}
