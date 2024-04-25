using DomainModel;

namespace Bus_Shuttle.Services
{
    public interface IDriverService
    {
        public void CreateDriver(int id, string firstNameame, string lastNameame);

        public List<Driver> GetAllDrivers();

        public int GetNumberOfDrivers();
    }
}