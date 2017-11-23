using JobsPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsPortal.Services
{
    public interface IJobOfferService
    {
        Task AddJobOferAsync(JobOfferViewModel jobOffer);

        Task<IEnumerable<JobOfferViewModel>> GetAllJobOfferAsync();

        Task<IEnumerable<JobOfferViewModel>> GetJobOfferByCompanyIdAsync(string companyId);

        Task<JobOfferViewModel> GetJobOfferByIdAsync(int id);

        List<string> JobSuggestBoxSearch(string name); 
    }
}
