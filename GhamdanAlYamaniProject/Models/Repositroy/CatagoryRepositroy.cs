using GhamdanAlYamaniProject.Data;
using GhamdanAlYamaniProject.Models.Interface;

namespace GhamdanAlYamaniProject.Models.Repositroy
{
    public class CatagoryRepositroy : IBaseRepository<Catagory>
    {
        private readonly ProjectDbContext _context;
        public CatagoryRepositroy(ProjectDbContext ctx)
        {
            _context = ctx;
        }
        public void Add(Catagory item)
        {
            _context.Catagorys.Add(item);
            _context.SaveChanges(); 
        }

        public void Delete(Catagory item)
        {
            _context.Catagorys.Remove(item);
            _context.SaveChanges();
        }

        public Catagory Find(int Id)
        {
            return _context.Catagorys.Find(Id);
        }

        public IEnumerable<Catagory> GetAll()
        {
            return _context.Catagorys;
        }

        public void Update(Catagory item)
        {
            _context.Catagorys.Update(item);
            _context.SaveChanges();
        }
    }
}
