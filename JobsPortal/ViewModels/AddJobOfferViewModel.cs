using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobsPortal.ViewModels
{
    public class AddJobOfferViewModel
    {
        public JobOfferViewModel JobOfferViewModel { get; set; }

        public IEnumerable<JobCategoriesViewModel> JobCategoriesViewModel { get; set; }
    }
}