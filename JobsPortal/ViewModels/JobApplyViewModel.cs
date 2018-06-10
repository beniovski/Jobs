using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobsPortal.ViewModels
{
    public class JobApplyViewModel
    {
        public JobOfferViewModel JobOfferViewModel { get; set; }

        public ApplyJobOfferViewModel ApplyJobOfferViewModel { get; set; }
    }
}