using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobsPortal.Models;
using System.Threading.Tasks;

namespace JobsPortal.Repositories
{
    public class JobCategoriesRepository : DbConnection, IJobCategoryRepository
    {
        public JobCategoriesRepository() : base()
        {

        }

        public async Task<IEnumerable<JobCategoriesViewModel>> GetAllJobCategories()
        {
            return _dbContext.JobOfferCategoriesViewModel.ToList();
        }
    }
}