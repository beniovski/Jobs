using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using JobsPortal.Models;

namespace JobsPortal.Repositories
{
    public class JobRepository : IJobOfferRepositories
    {
        private readonly ApplicationDbContext _dbContext;

        public JobRepository()
        {
            _dbContext = new ApplicationDbContext();
        }

        public async Task AddJobOfferAsync(JobOfferViewModel jobOffer)
        {
            _dbContext.JobOfferViewModel.Add(jobOffer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task GetAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}