using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using JobsPortal.Models;
using JobsPortal.Repositories;
using JobsPortal.ViewModels;

namespace JobsPortal.Services
{
    public class JobOfferService : IJobOfferService
    {
        private readonly IJobOfferRepositories _jobOfferRepository;

        public JobOfferService(IJobOfferRepositories jobOfferRepositories)
        {
            _jobOfferRepository = jobOfferRepositories;
        }

        public async Task AddJobOferAsync(AddJobOfferViewModel jobOffer)
        {
            var jobOfferMap = Mapper.Map<JobOffer>(jobOffer);
            await _jobOfferRepository.AddJobOfferAsync(jobOfferMap);
        }

        public async Task<IEnumerable<JobOfferViewModel>> GetAllJobOfferAsync()
        {
            var getJob = await _jobOfferRepository.GetAllAsync();
            return Mapper.Map<IEnumerable<JobOffer>, IEnumerable<JobOfferViewModel>>(getJob);
        }

        public async Task<IEnumerable<JobOfferViewModel>> GetJobOfferByCompanyIdAsync(string companyId)
        {
            var jobOffer = await _jobOfferRepository.GetAsyncByCompanyId(companyId);
            return Mapper.Map<IEnumerable<JobOffer>, IEnumerable<JobOfferViewModel>>(jobOffer);
        }

        public async Task<JobOfferViewModel> GetJobOfferByIdAsync(int id)
        {
            var getJobOffer = await _jobOfferRepository.GetAsync(id);
            return Mapper.Map<JobOffer, JobOfferViewModel>(getJobOffer);
        }

        public List<string> JobSuggestBoxSearch(string name)
        {
            return  _jobOfferRepository.JobSuggestBoxSearch(name);
        }

        public async Task EditJobOfferAsync(JobOfferViewModel jobOffer)
        {
           await _jobOfferRepository.UpdateJobOfferAsync(Mapper.Map<JobOfferViewModel, JobOffer>(jobOffer));
        }

        public async Task ArchiveJobOfferAsync(int id)
        {
            await _jobOfferRepository.ArchiveJobOfferAsync(id);
        }

        public async Task<IEnumerable<JobOfferViewModel>> GetArchiveJobOfferByCompanyIdAsync(string companyId)
        {
            var jobOffer = await _jobOfferRepository.GetArchiveByCompanyId(companyId);
            return Mapper.Map<IEnumerable<JobOffer>, IEnumerable<JobOfferViewModel>>(jobOffer);
        }
    }
}