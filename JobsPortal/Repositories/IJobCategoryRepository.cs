using JobsPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace JobsPortal.Repositories
{
    public interface IJobCategoryRepository
    {
       Task <IEnumerable<JobCategories>> GetAllJobCategories();
    }
}