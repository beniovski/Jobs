using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobsPortal.ViewModels
{
    public class IndexHomeViewModel
    {
        public MainSearchConsoleViewModel MainSearchConsoleViewModel {  get; set; }

        public IEnumerable<JobOfferViewModel> JobOfferViewModel { get; set; }

        public IndexHomeViewModel()
        {
            MainSearchConsoleViewModel = new MainSearchConsoleViewModel();                   

        }
    }
}