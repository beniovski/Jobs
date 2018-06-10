using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobsPortal.ViewModels
{
    public class SearchJobOfferViewModel
    {
        public IPagedList<JobOfferViewModel> JobOfferViewModel { get; set; }

        public IndexSearchJobOfferViewModel IndexSearchJobOfferViewModel { get; set; }

        public SearchConsoleViewModel SearchConsoleViewModel { get; set; }

        public IList<JobCategoriesViewModel> CategoriesViewModel { get; set; }    
        
        public SearchJobOfferViewModel()
        {
            CategoriesViewModel = new List<JobCategoriesViewModel>();
        }
               
    }
}