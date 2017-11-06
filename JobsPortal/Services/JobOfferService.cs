using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using JobsPortal.Models;
using JobsPortal.Repositories;

namespace JobsPortal.Services
{
    public class JobOfferService : IJobOfferService
    {
        private readonly IJobOfferRepositories _jobOfferRepository;

        public JobOfferService(IJobOfferRepositories jobOfferRepositories)
        {
            _jobOfferRepository = jobOfferRepositories;
        }

        public async Task AddJobOferAsync(JobOfferViewModel jobOffer)
        {
            await _jobOfferRepository.AddJobOfferAsync(jobOffer);
        }

        public async Task<IEnumerable<JobOfferViewModel>> GetAllJobOfferAsync()
        {
            return await _jobOfferRepository.GetAllAsync();
        }

        public async Task<JobOfferViewModel> GetJobOfferByIdAsync(int id)
        {
            return await _jobOfferRepository.GetAsync(id);
        }

        public List<string> JobSuggestBoxSearch(string name)
        {
            return  _jobOfferRepository.JobSuggestBoxSearch(name);
        }

    }
}