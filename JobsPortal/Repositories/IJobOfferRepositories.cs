using System.Collections.Generic;
using System.Threading.Tasks;
using JobsPortal.Models;

namespace JobsPortal.Repositories
{
    public interface IJobOfferRepositories
    {
        Task AddJobOfferAsync(JobOffer jobOffer);

        Task UpdateJobOfferAsync(JobOffer jobOffer);

        Task ArchiveJobOfferAsync(int id);       

        Task<IEnumerable<JobOffer>> GetAllAsync();

        Task<JobOffer> GetAsync(int id);

        Task<IEnumerable<JobOffer>> GetAsyncByCompanyId(string id);

        Task<IEnumerable<JobOffer>> GetArchiveByCompanyId(string id);

        Task<IEnumerable<JobOffer>> JobSearchingAsync(string city, string phrase);

        Task<IEnumerable<JobOffer>> JobSearchingAsync(int categoryId, string city, string phrase);

        List<string> JobSuggestBoxSearch(string name);

        List<string> CitySuggestBox(string city);

    }
}
