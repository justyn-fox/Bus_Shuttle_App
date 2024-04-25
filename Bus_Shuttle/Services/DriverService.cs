using DomainModel;

namespace Bus_Shuttle.Services
{
    public class DriverService : IDriverService
    {
        private DataContext _context;
        List<Driver> drivers;

        public void CreateDriver(int id, string firstName, string lastName)
        {
            _context = new DataContext();
            _context.Add(new Driver {Id=id, FirstName=firstName, LastName=lastName});
            _context.SaveChanges();
        }

        public List<Driver> GetAllDrivers()
        {
            _context = new DataContext();
            drivers = _context.Drivers
                .Select(d => new Driver(d.Id, d.FirstName, d.LastName)).ToList();
            return drivers;
        }

        public int GetNumberOfDrivers()
        {
            _context = new DataContext();
            return _context.Drivers.Count();
        }
    }
}