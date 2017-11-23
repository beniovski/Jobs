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
       Task AddJobOfferAsync(JobOfferViewModel jobOffer);

       Task<IEnumerable<JobOfferViewModel>> GetAllAsync();

       Task<JobOfferViewModel> GetAsync(int id);

       Task<IEnumerable<JobOfferViewModel>> GetAsyncByCompanyId(string id);

       List<string> JobSuggestBoxSearch(string name);

    }
}
