using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCProject.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string totalPrice { get; set; }
        public string address { get; set; }
        //[DataType("date")]
        public string date { get; set; }

        [ForeignKey("userRelation")]
        public string userId { get; set; }
        public ApplicationUser userRelation { get; set; }
        public List<OrderDetails> ordersList { get; set; }
        
    }
}
