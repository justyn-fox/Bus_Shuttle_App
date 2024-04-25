using DomainModel;

namespace Bus_Shuttle.Services
{
    public class StopService : IStopService
    {
        private DataContext _context;
        List<Stop> stops;

        public void CreateStop(int id, string name, double lat, double lon)
        {
            _context = new DataContext();
            _context.Add(new Stop {Id = id, Name = name, Latitude = lat, Longitude = lon});
            _context.SaveChanges();
        }

        public List<Stop> GetAllStops()
        {
            _context = new DataContext();
            stops = _context.Stops
                .Select(s => new Stop(s.Id, s.Name, s.Latitude, s.Longitude)).ToList();
            return stops;
        }

        public int GetNumberOfStops()
        {
            _context = new DataContext();
            return _context.Stops.Count();
        }
    }
}