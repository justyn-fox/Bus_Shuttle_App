using System.ComponentModel.DataAnnotations;
namespace DomainModel
{
    public class Loop
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}