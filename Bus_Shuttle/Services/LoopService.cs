using DomainModel;

namespace Bus_Shuttle.Services
{
    public class LoopService : ILoopService
    {
        private DataContext _context;
        List<Loop> loops;

        public void CreateLoop(int id, string name)
        {
            _context = new DataContext();
            var currentLoops = _context.Loops.Count();
            _context.Add(new Loop { Id = currentLoops + 1, Name = name});
            _context.SaveChanges();
        }

        public List<Loop> GetAllLoops()
        {
            _context = new DataContext();
            loops = _context.Loops
                .Select(l => new Loop(l.Id, l.Name)).ToList();
            return loops;
        }

        public int GetNumberOfLoops()
        {
            _context = new DataContext();
            return _context.Loops.Count();
        }
    }
}