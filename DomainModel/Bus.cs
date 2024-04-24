using System.ComponentModel.DataAnnotations;
namespace DomainModel
{
    public class Bus
    {
        [Key]
        public int Id { get; set; }
        public int BusNumber { get; set; }
    }
}