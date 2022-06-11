
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models
{
    public class Category
    {
     
        public int Id { get; set; }
        [Required(ErrorMessage = "Name Is Required ! ")]
        [MinLength(2, ErrorMessage = "Name Must Be Greater Than 3 Char !")]
        [MaxLength(20, ErrorMessage = "Name Must Be Lower Than 20 Char !")]
        public string name { get; set; }
        public string image { get; set; }

        public string type { get; set; }
        public List<Product> Products { get; set; }


    }
}
