﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using JobsPortal.Models;
using System.Collections;
using System.Data.Entity;

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

        public async Task<IEnumerable<JobOffer>> GetAllAsync() => await Task.FromResult(_dbContext.JobOffer.Where(x => x.IsActive));

        public async Task<IEnumerable<JobOffer>> GetAsyncByCompanyId(string id) => await Task.FromResult(_dbContext.JobOffer.Where(x => x.CompanyId == id && x.IsActive));

        public async Task<JobOffer> GetAsync(int id) => await Task.FromResult(_dbContext.JobOffer.FirstOrDefault(x => x.Id == id));

        public List<string> JobSuggestBoxSearch(string name) => _dbContext.JobOffer
                                                                 .Where(p => p.Title.Contains(name) && p.IsActive)
                                                                 .Select(p=>p.Title).Distinct().ToList();

        public List<string> CitySuggestBox(string city) => _dbContext.JobOffer
                                                                 .Where(p => p.City.Contains(city) && p.IsActive)
                                                                 .Select(p => p.City).Distinct().ToList();

        public async Task UpdateJobOfferAsync(JobOffer jobOffer)
        {
            var entity = _dbContext.JobOffer.Find(jobOffer.Id);

            entity.Country = jobOffer.Country;
            entity.SalaryMin = jobOffer.SalaryMin;
            entity.City = jobOffer.City;
            entity.Country = jobOffer.Country;
            entity.Descriptions = jobOffer.Descriptions;
            entity.Requaierments = jobOffer.Requaierments;
            _dbContext.SaveChanges();
        }

        public async Task ArchiveJobOfferAsync(int id)
        {
            var entity = _dbContext.JobOffer.Find(id);
            entity.IsActive = false;
            _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<JobOffer>> GetArchiveByCompanyId(string id)
            => await Task.FromResult(_dbContext.JobOffer.Where(x => x.CompanyId == id && !x.IsActive));


        public async Task<IEnumerable<JobOffer>> JobSearchingAsync(int categoryId, string city, string phrase)
            => await Task.FromResult(_dbContext.JobOffer.Where(x => x.IsActive && ( x.JobCategoriesId == categoryId && x.City == city ||
                (x.Descriptions.Contains(phrase)||x.Title.Contains(phrase)||x.Requaierments.Contains(phrase)) )));

        public async Task<IEnumerable<JobOffer>> JobSearchingAsync(string city, string phrase)
        {
            if(String.IsNullOrEmpty(city)&&String.IsNullOrEmpty(phrase))
            {
                return await Task.FromResult(_dbContext.JobOffer);
            }
            if (String.IsNullOrEmpty(city))
            {
                return await Task.FromResult(_dbContext.JobOffer.Where(x => x.Descriptions.Contains(phrase) || x.Title.Contains(phrase) || x.Requaierments.Contains(phrase)));
            }
            return await Task.FromResult(_dbContext.JobOffer.Where(x => x.City == city && (x.Descriptions.Contains(phrase) || x.Title.Contains(phrase) || x.Requaierments.Contains(phrase))));
            
        }
        
        public async Task<IEnumerable<JobOffer>> ColumnSearch(IEnumerable<JobCategories> selectedJobCategories, IEnumerable<State> selectedState, bool abroadSearch)
        {
            var selectedStateZero = selectedState.Count() == 0 ? true : false;
            // var getJobs = _dbContext.JobOffer.Where(x=>x.IsActive && (x.DateFrom< DateTime.Today && x.DateTo > DateTime.Today)).ToList();
            var getJobs = _dbContext.JobOffer.ToList();
            var result = Enumerable.Empty<JobOffer>();

            if (!abroadSearch&&!selectedStateZero)
            {
                 result = getJobs.Where(p => selectedJobCategories.Any(p2 => p2.Id == p.JobCategoriesId))
                             .Where(x => selectedState.Any(p3 => p3.Id == x.StateId))
                             .Where(x=>x.CountriesId == 13).ToList();
            }

            else if (abroadSearch && selectedStateZero)
            {
                 result = getJobs.Where(p => selectedJobCategories.Any(p2 => p2.Id == p.JobCategoriesId))                           
                            .Where(x => x.CountriesId != 13).ToList();
            }
            else
            {
                result = getJobs.Where(p => selectedJobCategories.Any(p2 => p2.Id == p.JobCategoriesId))
                               .Where(x => selectedState.Any(p3 => p3.Id == x.StateId)).ToList();
            }
            
            return result;
        }
    }
}