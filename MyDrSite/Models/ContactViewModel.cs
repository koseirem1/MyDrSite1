using System;

using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDrSite.Models
{
    public class ContactViewModel
    {
        [Required]
        [Display(Name ="E-Posta")]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Ad")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Display(Name = "Soyad")]
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Lütfen seçim yapınız")]
        [Display(Name = "Konu Başlığı")]
        public GunEnum Gunlere { get; set; }

        [Display(Name = "Mesajınız")]
        [MaxLength(40000)]
        [Required]

        public string Message { get; set; }

        public enum GunEnum
        {
            [Display(Name = "SİPARİŞİNİZ İLE İLGİLİ SORULARINIZ")] SIPARIŞINIZ_ILE_ILGILI_SORULARINIZ,

            [Display(Name = "İADELERİNİZ İLE İLGİLİ SORULARINIZ")] IADELERİNİZ_ILE_ILGILI_SORULARINIZ,

            [Display(Name = "ÜCRET İADESİ İLE İLGİLİ SORULARINIZ")] UCRET_IADESI_ILE_ILGILI_SORULARINIZ,

            [Display(Name = "SİPARİŞ İPTAL")] SIPARIŞ_IPTAL,
        }
    }
}