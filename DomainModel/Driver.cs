using System.ComponentModel.DataAnnotations;
namespace DomainModel
{
    public class Driver
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Driver(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public Driver(Driver driver)
        {
            Id = driver.Id;
            FirstName = driver.FirstName;
            LastName = driver.LastName;
        }

        public void Update(string FirstName, string LastName)
        {
            FirstName = FirstName;
            LastName = LastName;
        }
    }
}