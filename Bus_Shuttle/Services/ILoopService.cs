using DomainModel;

namespace Bus_Shuttle.Services
{
    public interface ILoopService
    {
        public void CreateLoop(int id, string name);

        public List<Loop> GetAllLoops();

        public int GetNumberOfLoops();
    }
}