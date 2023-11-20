using WebApplication3.Data;
using WebApplication3.Data.Entities;

namespace WebApplication3.Repositories
{
    public interface IDeviceEntityRepository
    {
        DeviceEntity Get(Guid id);
        List<DeviceEntity> GetAll();
        bool Add(DeviceEntity model);
        bool Update(DeviceEntity model);
        bool Delete(Guid id);
    }

    public class DeviceRepository : IDeviceEntityRepository
    {
        private readonly ApplicationDbContext _context;

        public DeviceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DeviceEntity Get(Guid id)
        {
            return _context.Device.FirstOrDefault(n => n.Id == id);
        }
        public List<DeviceEntity> GetAll()
        {
            return _context.Device.ToList();
        }

        public bool Add(DeviceEntity model)
        {
            _context.Device.Add(model);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(Guid id)
        {
            var model = Get(id);
            if (model != null)
            {
                _context.Device.Remove(model);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public bool Update(DeviceEntity model)
        {
            _context.Device.Update(model);
            return _context.SaveChanges() > 0;
        }
    }
}