using System.ComponentModel.DataAnnotations;
namespace DomainModel
{
    public class Loop
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public Loop(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Loop(string name)
        {
            Name = name;
        }

        public Loop(Loop loop)
        {
            Id = loop.Id;
            Name = loop.Name;
        }

        public void Update(string name)
        {
            Name = name;
        }
    }
}