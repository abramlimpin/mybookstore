using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBookstoreMVC.Models
{
    public class Publisher
    {
        [Key]
        public int PubID { get; set; }
        public string Name { get; set; }
    }
}