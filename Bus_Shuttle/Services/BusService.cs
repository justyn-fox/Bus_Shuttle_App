using DomainModel;

namespace Bus_Shuttle.Services
{
    public class BusService : IBusService
    {
        private DataContext _context;
        List<Bus> buses;

        public void CreateBus(int id, string name)
        {
            _context = new DataContext();
            _context.Add(new Bus { Id = id, BusName = name});
            _context.SaveChanges();
        }

        public List<Bus> GetAllBusses()
        {
            _context = new DataContext();
            buses = _context.Buses
                .Select(b => new Bus(b.Id, b.BusName)).ToList();
            return buses;
        }

        public int GetNumberOfBusses()
        {
            _context = new DataContext();
            return _context.Buses.Count();
        }
    }
}