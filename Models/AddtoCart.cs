using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmClient.Models
{
    public class AddtoCart
    {
        public int Cartid { get; set; }
        public int? Userid { get; set; }
        public int? Productid { get; set; }
        
        public string ProductImage { get; set; }
        public string Productname { get; set; }
        public string ProductDesc { get; set; }
        public float Price { get; set; }
    }
}
