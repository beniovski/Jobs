using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobsPortal.ViewModels
{
    public class ColumnSearchConsoleViewModel
    {
        public SearchConsoleViewModel SearchConsoleViewModel { get; set; }

        public IList<JobCategoriesViewModel> CategoriesViewModel { get; set; }

        public IList<StateViewModel> StateVievModel  { get; set; }
    }
}