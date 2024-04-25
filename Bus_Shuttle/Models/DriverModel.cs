using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using DomainModel;

namespace Bus_Shuttle.Models
{
    public class DriverCreateModel
    {
        public int Id { get; set; }
        
        [StringLength(30, MinimumLength = 2)]
        public string FirstName { get; set; }
        public string LastName { get; set;}

        public static DriverCreateModel NewDriver(int numberOfDrivers)
        {
            var newId = numberOfDrivers + 1;
            return new DriverCreateModel
            {
                Id = newId,
                FirstName = "",
                LastName = "",
            };
        }
    }

    public class DriverEditModel
    {
        public int Id { get; set; }
        [StringLength(30, MinimumLength = 2)]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public static DriverEditModel FromDriver(Driver driver)
        {
            return new DriverEditModel
            {
                Id = driver.Id,
                FirstName = driver.FirstName,
                LastName = driver.LastName,
            };
        }
    }

    public class DriverViewModel
    {
        public int Id { get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public static DriverViewModel FromDriver(Driver driver)
        {
            return new DriverViewModel
            {
                Id = driver.Id,
                FirstName = driver.FirstName,
                LastName = driver.LastName,
            };
        }
    }
}