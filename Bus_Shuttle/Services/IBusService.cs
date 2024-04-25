using DomainModel;

namespace Bus_Shuttle.Services
{
    public interface IBusService
    {
        public void CreateBus(int id, string name);

        public List<Bus> getAllBusses();

        public int GetAmountOfBusses();
    }
}