using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobsPortal.Models;
using PagedList;

namespace JobsPortal.ViewModels
{
    public class CompanyViewModel
    {
        public IPagedList<JobOfferViewModel> JobOfferView { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public ChangePasswordViewModel ChangePasswordViewModel { get; set; }

    }
}