using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmClient.Models
{
    public class CustomerDetail
    {
        //Userid,Username,Gender,Age,Address,Email,Phone,Password
        
        public int Userid { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Age is required")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Invalid Email ID")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone Number is required")]
        //[MaxLength(10, ErrorMessage = "Phone Number must be 10 numbers")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Give valid mobile number")]
        //[DataType(DataType.PhoneNumber, ErrorMessage = "Invalid Phone number")]
        public long? Phone { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Password must be 3 characters")]
        public string Password { get; set; }
        public CustomerDetail()
        {
            Email = "bala@gmail.com";
            Password = "bala";
        }
    }
}
