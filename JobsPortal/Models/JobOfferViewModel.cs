using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobsPortal.Models
{
    public class JobOfferViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nazwa stanowiska")]
        [Required(ErrorMessage = "Nazwa Stanowiska nie może być pusta"), MinLength(3), MaxLength(30)]
        public string Title { get; set; }

        [Display(Name = "Nazwa Państwa")]
        public string Country { get; set; }

        [Display(Name = "Miasto")]
        public string City { get; set; }

        [Display(Name = "Opis stanowiska ")]
        [Required(ErrorMessage = "Opis nie może być pusty")]
        public string Description { get; set; }

        [Display(Name = "Wymagania : ")]
        [Required(ErrorMessage = "Wymagania nie mogą być puste")]
        public string Requaierments { get; set; }

        [Display(Name = "Kategoria")]
        public string Category { get; set; }

        [Display(Name = "Start publikacji")]
        [Required(ErrorMessage = "początek publikacji nie może być pusta")]
        public DateTime DateFrom { get; set; }

        [Display(Name = "Koniec publikacji")]
        [Required(ErrorMessage = "data końca publikacji nie może być pusta")]
        public DateTime DateTo { get; set; }

        [Display(Name = "Minimalne zarobki " )]
        [Required(ErrorMessage = "Kwota mninmalna nie moze byc pusta")]
        public Decimal SalaryMin { get; set; }

        public Decimal SalaryMax { get; set; }

        public string CompanyId { get; set; }

        public ApplicationUser Company { get; set; }
    }
}