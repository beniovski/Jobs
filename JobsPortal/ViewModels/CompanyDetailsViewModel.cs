using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobsPortal.ViewModels
{
    public class CompanyDetailsViewModel
    {

        [AllowHtml, DataType(DataType.Html)]
        [Display(Name = "Opis Firmy ")]
        public string Description { get; set; }

    }
}