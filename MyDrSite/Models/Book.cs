using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyDrSite.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Display(Name = "Kitap Adı")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Display(Name = "Yazarlar")]
        public int? AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }

        [Required]
        [MaxLength(100)]
       
        [Display(Name = "Yayınevi")]
        public string Publisher { get; set; }

    
    }
}