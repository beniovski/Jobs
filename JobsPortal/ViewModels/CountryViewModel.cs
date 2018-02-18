using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobsPortal.ViewModels
{
    public class CountryViewModel
    {
        public int Id { get; set; }

        public string CountryName { get; set; }

        HashSet<CountryViewModel> countryViewModel;

        public CountryViewModel()
        {
            countryViewModel = new HashSet<CountryViewModel>();
        }
    }
}