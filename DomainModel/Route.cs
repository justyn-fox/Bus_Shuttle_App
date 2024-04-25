using System.ComponentModel.DataAnnotations;
namespace DomainModel
{
    public class Route
    {
        [Key]
        public int Id { get; set; }
        public int Order { get; set; }

        public Route(int id, int order)
        {
            Id = id;
            Order = order;
        }

        public Route(int order)
        {
            Order = order;
        }

        public Route(Route route)
        {
            Id = route.Id;
            Order = route.Order;
        }

        public void Update(int order)
        {
            Order = order;
        }
    }
}