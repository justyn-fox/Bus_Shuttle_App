using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using DomainModel;

namespace Bus_Shuttle.Models
{
    public class LoopCreateModel
    {
        public int Id { get; set; }

        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        public static LoopCreateModel NewLoop(int numberOfLoops)
        {
            var newId = numberOfLoops + 1;

            return new LoopCreateModel
            {
                Id = newId,
                Name = "",
            };
        }
    }

    public class LoopEditModel
    {
        public int Id { get; set; }

        [StringLength(30, MinimumLength = 3)]

        public string Name { get; set; }

        public static LoopEditModel FromLoop(Loop loop)
        {
            return new LoopEditModel
            {
                Id = loop.Id,
                Name = loop.Name,
            };
        }
    }

    public class LoopViewModel
    {
        public int Id { get; set;}
        public string Name { get; set; }

        public static LoopViewModel From(Loop loop)
        {
            return new LoopViewModel
            {
                Id = loop.Id,
                Name = loop.Name
            };
        }
    }
}