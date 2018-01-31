using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobsPortal.Models;

namespace JobsPortal.ViewModels
{
    public class EditJobOfferViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nazwa stanowiska")]
        [Required(ErrorMessage = "Nazwa Stanowiska nie może być pusta"), MinLength(3), MaxLength(30)]
        public string Title { get; set; }

        [Display(Name = "Nazwa Państwa")]
        public string Country { get; set; }

        [Display(Name = "Miasto")]
        public string City { get; set; }    

        [AllowHtml, DataType(DataType.Html)]
        [Display(Name = "Opis stanowiska ")]
        [MaxLength(4000)]
        [Required(ErrorMessage = "Opis nie może być pusty")]
        public string Descriptions { get; set; }

        [AllowHtml, DataType(DataType.Html)]
        [Display(Name = "Wymagania : ")]
        [MaxLength(4000)]
        [Required(ErrorMessage = "Wymagania nie mogą być puste")]
        public string Requaierments { get; set; }

        [Display(Name = "Kategoria")]
        public string Category { get; set; }

        [Display(Name = "Start publikacji")]
        [Required(ErrorMessage = "początek publikacji nie może być pusta")]
        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; } 

        [Display(Name = "Minimalne zarobki " )]
        [Required(ErrorMessage = "Kwota mninmalna nie moze byc pusta")]
        public Decimal SalaryMin { get; set; }

        [Display(Name = "Maksymalne zarobki")]
        public Decimal SalaryMax { get; set; }

        public string CompanyId { get; set; }

        public bool IsActive { get; set; }

        public int JobCategoriesId { get; set; }

        public JobCategoriesViewModel JobCategories { get; set; }

        public ApplicationUser Company { get; set; }
    }
}