using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobsPortal.ViewModels
{
    public class SearchJobOfferViewModel
    {
        public String SearchType { get; set; }

        public IPagedList<JobOfferViewModel> JobOfferViewModel { get; set; }

        public MainSearchConsoleViewModel MainSearchConsoleViewModel { get; set; }
        
        public SearchConsoleViewModel SearchConsoleViewModel { get; set; }

        public  ColumnSearchConsoleViewModel ColumnSearchConsoleViewModel { get; set; }
               
    }
}