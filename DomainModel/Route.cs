using System.ComponentModel.DataAnnotations;
namespace DomainModel
{
    public class Route
    {
        [Key]
        public int Id { get; set; }
        public int Order { get; set; }
    }
}