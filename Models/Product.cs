using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmClient.Models
{
    public class Product
    {
        public int Productid { get; set; }
        [Required(ErrorMessage = "Product image is required")]
        public string ProductImage { get; set; }
        [Required(ErrorMessage = "Product name is required")]
        public string Productname { get; set; }
        public string ProductDesc { get; set; }
        [Required(ErrorMessage = "Product price is required")]
        public float Price { get; set; }
    }
}
