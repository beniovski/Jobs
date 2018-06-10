using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobsPortal.ViewModels
{
    public class ApplyJobOfferViewModel
    {
        [Required]
        [DisplayName("Podaj adres Email")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Podaj imie")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Podaj nazwisko")]
        public string Surname { get; set; }

        [DisplayName("Wiadomość ")]
        public string Meesage { get; set; }

       
        [DisplayName("CV w formacie doc lub pdf")]
        public HttpPostedFileBase CvFile { get; set; }

    }
}