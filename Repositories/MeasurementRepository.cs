using WebApplication3.Data;
using WebApplication3.Data.Entities;

namespace WebApplication3.Repositories
{
    public interface IMeasurementRepository
    {
        MeasurementEntity Get(Guid id);

        List<MeasurementEntity>GetAll();
        bool Add(MeasurementEntity model);
        bool Update(MeasurementEntity model);
       bool Delete(Guid id);
    }
    public class MeasurementRepository : IMeasurementRepository
    {
        private readonly ApplicationDbContext _context;

        public MeasurementRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public MeasurementEntity Get(Guid id)
        {
            return _context.Measurement.FirstOrDefault(n => n.Id == id);
        }

        public List<MeasurementEntity> GetAll()
        {
            return _context.Measurement.Select(n=>n).ToList();
        }
        public bool Add(MeasurementEntity model)
        {
            _context.Measurement.Add(model);
            return _context.SaveChanges() >0;
        }

        public bool Delete(Guid id)
        {
            var model =Get(id);
            _context.Measurement.Remove(model);
            return _context.SaveChanges() > 0;
        }

        public bool Update(MeasurementEntity model)
        {
            _context.Measurement.Update(model);
            return _context.SaveChanges() > 0;
        }
    }
}
