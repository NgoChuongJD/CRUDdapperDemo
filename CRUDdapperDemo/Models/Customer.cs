using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDdapperDemo.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        [Required(ErrorMessage ="Enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Enter Address")]
        public string Address { get; set; }
        [Required(ErrorMessage ="Enter Country")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Enter City")]
        public string City { get; set; }
        [Required(ErrorMessage = "Enter Phone Number")]
        public string Phoneno { get; set; }
    }
}