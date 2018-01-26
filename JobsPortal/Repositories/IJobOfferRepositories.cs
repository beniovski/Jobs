using JobsPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsPortal.Repositories
{
    public interface IJobOfferRepositories
    {
       Task AddJobOfferAsync(JobOffer jobOffer);

       Task<IEnumerable<JobOffer>> GetAllAsync();

       Task<JobOffer> GetAsync(int id);

       Task<IEnumerable<JobOffer>> GetAsyncByCompanyId(string id);

       List<string> JobSuggestBoxSearch(string name);

    }
}
