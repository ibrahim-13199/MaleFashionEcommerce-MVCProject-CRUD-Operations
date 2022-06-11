using System.ComponentModel.DataAnnotations.Schema;

namespace MVCProject.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("orderRelation")]
        public int orderId { get; set; }
        public Order orderRelation { get; set; }

        [ForeignKey("productRelation")]
        public int ProductId { get; set; }
        public Product productRelation { get; set; }
    }
}
