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

        HashSet<StateViewModel> stateViewModel;

        public StateViewModel()
        {
            stateViewModel = new HashSet<StateViewModel>();
        }
    }
}