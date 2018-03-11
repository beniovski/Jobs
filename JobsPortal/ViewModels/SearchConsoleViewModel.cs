using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobsPortal.ViewModels
{
    public class SearchConsoleViewModel
    {
        public IEnumerable<CountryViewModel> CountryViewModel { get; set; }

        public IEnumerable<JobCategoriesViewModel> JobCategoriesViewModel { get; set; }

        public int selectedCategory { get; set; }

        public string citySearch { get; set; }

        public string phraseSearch { get; set; }

    }
}