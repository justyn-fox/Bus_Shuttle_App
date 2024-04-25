using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using DomainModel;

namespace Bus_Shuttle.Models
{
    public class BusCreateModel
    {
        public int Id { get; set; }

        [StringLength(30, MinimumLength = 3)]
        public string BusName { get; set; }

        public static BusCreateModel NewBus(int numberOfBuses)
        {
            var newId = numberOfBuses + 1;
            return new BusCreateModel
            {
                Id = newId,
                BusName = "",
            };
        }
    }

    public class BusEditModel
    {
        public int Id { get; set; }

        [StringLength(30, MinimumLength = 3)]
        public string BusName { get; set; }

        public static BusEditModel FromBus(Bus bus)
        {
            return new BusEditModel
            {
                Id = bus.Id,
                BusName = bus.BusName,
            };
        }
    }

    public class BusViewModel
    {
        public int Id { get; set;}
        public string BusName { get; set;}
        public static BusViewModel FromBus(Bus bus)
        {
            return new BusViewModel
            {
                Id = bus.Id,
                BusName = bus.BusName,
            };
        }
    }
}