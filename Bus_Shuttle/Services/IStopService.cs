using DomainModel;

namespace Bus_Shuttle.Services
{
    public interface IStopService
    {
        public void CreateStop(int id, string name, double lat, double lon);

        public List<Stop> GetAllStops();

        public int GetNumberOfStops();
    }
}