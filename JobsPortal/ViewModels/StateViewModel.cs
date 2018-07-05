using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobsPortal.ViewModels
{
    public class StateViewModel
    {
        public int Id { get; set; }      

        public string StateName { get; set; }

        public bool IsChecked { get; set; }

        IList<JobOfferViewModel> JobOfferViewModel;

        public StateViewModel()
        {
            JobOfferViewModel = new List<JobOfferViewModel>();
        }
    }
}
