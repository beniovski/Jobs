using JobsPortal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using JobsPortal.Repositories;
using JobsPortal.ViewModels;
using Microsoft.AspNet.Identity;

namespace JobsPortal.Controllers
{
    public class JobOfferController : Controller
    {
        private readonly IJobOfferService _jobOfferService;
        private readonly IJobCategoryService _jobCategoryService;
        private readonly ICountryService _countryService;

        public JobOfferController(IJobOfferService jobOfferService, IJobCategoryService jobCategoryService, ICountryService countryService)
        {
            _jobCategoryService = jobCategoryService;
            _countryService = countryService;
            _jobOfferService = jobOfferService;
        }

        [HttpGet]
        public async Task<ActionResult> JobSearch(SearchJobOfferViewModel scvm)
        {
           var jobsOffer = await _jobOfferService.JobSearchingAsync(scvm.SearchConsoleViewModel.selectedCategory, scvm.SearchConsoleViewModel.citySearch,
                scvm.SearchConsoleViewModel.phraseSearch);

            var sjovm = new SearchJobOfferViewModel();
            var scvmn = new SearchConsoleViewModel();

            scvmn.JobCategoriesViewModel = await _jobCategoryService.GetAllJobCategoriesAsync();
            scvmn.CountryViewModel = await _countryService.GetAllCountriesAsync();
            scvmn.selectedCategory = scvm.SearchConsoleViewModel.selectedCategory;
            sjovm.SearchConsoleViewModel = scvmn;
            
            sjovm.JobOfferViewModel = jobsOffer;

            return View("AllOfers", sjovm);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var jobOffer = await _jobOfferService.GetJobOfferByIdAsync(id);
            return View(jobOffer);
        }
         
        public async Task<ActionResult> AllOfers()
        {
            var jobOffers = await _jobOfferService.GetAllJobOfferAsync();

            var sjovm = new SearchJobOfferViewModel();
            var scvm = new SearchConsoleViewModel();
            scvm.JobCategoriesViewModel = await _jobCategoryService.GetAllJobCategoriesAsync();
            scvm.CountryViewModel = await _countryService.GetAllCountriesAsync();
            sjovm.SearchConsoleViewModel = scvm;
            sjovm.JobOfferViewModel = await _jobOfferService.GetAllJobOfferAsync();          
          

            return View(sjovm);
        }


        public async Task<ActionResult> DetailsCopy()
        {
            return View();
        }

    }
}