using JobsPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobsPortal.ViewModels;

namespace JobsPortal.Services
{
    public interface IJobOfferService
    {
        Task AddJobOferAsync(AddJobOfferViewModel jobOffer);

        Task ArchiveJobOfferAsync(int id);

        Task EditJobOfferAsync(JobOfferViewModel jobOffer);

        Task<IEnumerable<JobOfferViewModel>> GetAllJobOfferAsync();

        Task<IEnumerable<JobOfferViewModel>> GetJobOfferByCompanyIdAsync(string companyId);

        Task<JobOfferViewModel> GetJobOfferByIdAsync(int id);

        List<string> JobSuggestBoxSearch(string name); 
    }
}
