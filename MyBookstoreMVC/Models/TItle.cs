using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyBookstoreMVC.Models
{
    public class Title
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Publisher")]
        public virtual int PubID { get; set; }
        public virtual Publisher publisher { get; set; }
        [ForeignKey("Author")]
        public virtual int AuthorID { get; set; }
        public virtual Author author { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime PubDate { get; set; }
        public string Notes { get; set; }

    }
}