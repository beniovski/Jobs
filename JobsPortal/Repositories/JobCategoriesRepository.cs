using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public async Task<IEnumerable<JobCategories>> GetAllJobCategories()
        {
            return _dbContext.JobOfferCategories;
        }
    }
}