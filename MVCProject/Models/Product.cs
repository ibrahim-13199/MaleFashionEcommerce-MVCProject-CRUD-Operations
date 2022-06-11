using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title Is Required ! ")]
        public string tilte { get; set; }
        public string image { get; set; }
        public decimal price { get; set; }
        public string describtion { get; set; }

        [ForeignKey("categoryRelation")]
        public int categoryId { get; set; }
        public Category categoryRelation { get; set; }

        public List<OrderDetails> ordersList { get; set; }

    }
}
