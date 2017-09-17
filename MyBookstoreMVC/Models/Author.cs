using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyBookstoreMVC.Models
{
    public class Author
    {
        [Key]
        public int ID { get; set; }
        [Display(Name ="Last Name")]

        public string LastName { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name ="Phone")]
        public string Phone { get; set; }
        [Display(Name = "Address")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        [Display(Name ="City")]
        public string City { get; set; }
        [Display(Name ="State")]
        public string State { get; set; }
        [Display(Name ="Zip Code")]
        public string Zip { get; set; }
        
    }
}