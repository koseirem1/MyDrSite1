using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyDrSite.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Yazar Adı")]
        [MaxLength(100)]
        public string FullName { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}