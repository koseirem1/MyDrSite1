using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyDrSite.Models
{
    public class Film
    {
        public int Id { get; set; }

        [Display(Name = "Film Adı")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Film Açıklaması")]
        public string Description { get; set; }

        [DataType(DataType.Html)]
        public string Body { get; set; }

        [Display(Name = "Kategoriler")]
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}