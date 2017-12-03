using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using JobsPortal.Models;
using System.Collections;

namespace JobsPortal.Repositories
{
    public class JobRepository : DbConnection, IJobOfferRepositories
    { 
        public JobRepository() : base()
        {

        }

        public async Task AddJobOfferAsync(JobOffer jobOffer)
        {
            _dbContext.JobOffer.Add(jobOffer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task <IEnumerable<JobOffer>> GetAllAsync()
        {
            return _dbContext.JobOffer;
        }

        public async Task<IEnumerable<JobOffer>> GetAsyncByCompanyId(string id) => await Task.FromResult(_dbContext.JobOffer.Where(x => x.CompanyId == id));

        public async Task<JobOffer> GetAsync(int id) => await Task.FromResult(_dbContext.JobOffer.FirstOrDefault(x => x.Id == id));

        public List<string> JobSuggestBoxSearch(string name) => _dbContext.JobOffer
                                                                 .Where(p => p.Title.Contains(name))
                                                                 .Select(p=>p.Title).ToList();       



    }
}