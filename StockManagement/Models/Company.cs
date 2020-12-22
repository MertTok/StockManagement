using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagement.Models
{
    public class Company : ModelBase
    {
        [Key]
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Company")]
        public int CompanyID { get; set; }


        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Is Active")]
        public bool IsActiveProvider { get; set; }


        public List<Product> Products { get; set; }
    }
}
