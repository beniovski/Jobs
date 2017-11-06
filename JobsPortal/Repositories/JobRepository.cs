using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using JobsPortal.Models;
using System.Collections;

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

        public async Task <IEnumerable<JobOfferViewModel>> GetAllAsync()
        {
            return _dbContext.JobOfferViewModel;
        }

        public async Task<JobOfferViewModel> GetAsync(int id) => await Task.FromResult(_dbContext.JobOfferViewModel.FirstOrDefault(x => x.Id == id));

        public List<string> JobSuggestBoxSearch(string name) => _dbContext.JobOfferViewModel
                                                                 .Where(p => p.Title.Contains(name))
                                                                 .Select(p=>p.Title).ToList();
            


    }
}