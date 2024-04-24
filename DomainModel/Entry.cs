using System.ComponentModel.DataAnnotations;
namespace DomainModel
{
    public class Entry
    {
        [Key]
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public int Boarded { get; set; }
        public int LeftBehind { get; set; }
    }
}