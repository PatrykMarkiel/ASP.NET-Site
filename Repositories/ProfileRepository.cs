using WebApplication3.Data;
using WebApplication3.Data.Entities;

namespace WebApplication3.Repositories
{
    public interface IProfileEntityRepository
    {
        ProfileEntity Get(Guid id);
        List<ProfileEntity> GetAll();
        bool Add(ProfileEntity model);
        bool Update(ProfileEntity model);
        bool Delete(Guid id);
    }

    public class ProfileRepository : IProfileEntityRepository
    {
        private readonly ApplicationDbContext _context;

        public ProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ProfileEntity Get(Guid id)
        {
            return _context.Profiles.FirstOrDefault(n => n.Id == id);
        }
        public List<ProfileEntity> GetAll()
        {
            return _context.Profiles.ToList();
        }

        public bool Add(ProfileEntity model)
        {
            _context.Profiles.Add(model);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(Guid id)
        {
            var model = Get(id);
            if (model != null)
            {
                _context.Profiles.Remove(model);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public bool Update(ProfileEntity model)
        {
            _context.Profiles.Update(model);
            return _context.SaveChanges() > 0;
        }
    }
}