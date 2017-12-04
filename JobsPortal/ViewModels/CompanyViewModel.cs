using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobsPortal.Models;

namespace JobsPortal.ViewModels
{
    public class CompanyViewModel
    {
        public IEnumerable<JobOfferViewModel> JobOfferView { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

    }
}