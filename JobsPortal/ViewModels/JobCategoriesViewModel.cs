using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobsPortal.ViewModels
{
    public class JobCategoriesViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        HashSet<JobOfferViewModel> JobOfferViewModel;

        public JobCategoriesViewModel()
        {
            JobOfferViewModel = new HashSet<JobOfferViewModel>();
        }
    }
}