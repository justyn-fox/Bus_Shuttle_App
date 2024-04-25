using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using DomainModel;

namespace Bus_Shuttle.Models
{
    public class StopCreateModel
    {
        public int Id { get; set; }

        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public static StopCreateModel NewStop(int numberOfStops)
        {
            var newId = numberOfStops + 1;
            return new StopCreateModel
            {
                Id = newId,
                Name = "",
                Latitude = 0.0,
                Longitude = 0.0,
            };
        }
    }

    public class StopEditModel
    {
        public int Id { get; set; }

        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        public static StopEditModel FromStop(Stop stop)
        {
            return new StopEditModel
            {
                Id = stop.Id,
                Name = stop.Name,
            };
        }
    }

    public class StopViewModel
    {
        public int Id { get; set;}
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public static StopViewModel FromStop(Stop stop)
        {
            return new StopViewModel
            {
                Id = stop.Id,
                Name = stop.Name,
                Latitude = stop.Latitude,
                Longitude = stop.Longitude,
            };
        }
    }
}