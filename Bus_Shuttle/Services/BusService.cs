using DomainModel;

namespace Bus_Shuttle.Services
{
    public class BusServices
    {
        private DataContext _context;
        List<Bus> buses;

        public void CreatNewBus(int id, string name)
        {
            _context = new DataContext();
            _context.Add(new Bus { Id = id, BusName = name});
            _context.SaveChanges();
        }
    }
}