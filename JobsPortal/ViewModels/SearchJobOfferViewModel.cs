using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobsPortal.ViewModels
{
    public class SearchJobOfferViewModel
    {
        public IEnumerable<JobOfferViewModel> JobOfferViewModel { get; set; }

        public SearchConsoleViewModel SearchConsoleViewModel { get; set; }
       
    }
}