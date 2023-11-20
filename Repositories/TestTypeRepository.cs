using WebApplication3.Data;
using WebApplication3.Data.Entities;

namespace WebApplication3.Repositories
{
    public interface ITestTypeEntityRepository
    {
        TestTypeEntity Get(Guid id);
        List<TestTypeEntity> GetAll();
        bool Add(TestTypeEntity model);
        bool Update(TestTypeEntity model);
        bool Delete(Guid id);
    }

    public class TestTypeRepository : ITestTypeEntityRepository
    {
        private readonly ApplicationDbContext _context;

        public TestTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public TestTypeEntity Get(Guid id)
        {
            return _context.TestType.FirstOrDefault(n => n.Id == id);
        }
        public List<TestTypeEntity> GetAll()
        {
            return _context.TestType.ToList();
        }

        public bool Add(TestTypeEntity model)
        {
            _context.TestType.Add(model);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(Guid id)
        {
            var model = Get(id);
            if (model != null)
            {
                _context.TestType.Remove(model);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public bool Update(TestTypeEntity model)
        {
            _context.TestType.Update(model);
            return _context.SaveChanges() > 0;
        }
    }
}