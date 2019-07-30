using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyDrSite.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Display(Name = "Kategori Adı")]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Film> Films { get; set; }

    }
}