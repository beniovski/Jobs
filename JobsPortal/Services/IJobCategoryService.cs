﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobsPortal.ViewModels;

namespace JobsPortal.Services
{
    public interface IJobCategoryService
    {
       Task <IEnumerable<JobCategoriesViewModel>> GetAllJobCategoriesAsync();
    }
}
