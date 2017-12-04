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
    public class JobCategoryService : IJobCategoryService
    {
        private readonly IJobCategoryRepository  _jobCategoryRepository;

        public JobCategoryService(IJobCategoryRepository jobCategoryRepository)
        {
            _jobCategoryRepository = jobCategoryRepository;
        }
        public async Task<IEnumerable<JobCategoriesViewModel>> GetAllJobCategoriesAsync()
        {
            var getCategories = await _jobCategoryRepository.GetAllJobCategories();
            return Mapper.Map<IEnumerable<JobCategories>, IEnumerable<JobCategoriesViewModel>>(getCategories);
        }
    }
}