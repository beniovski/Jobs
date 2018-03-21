using JobsPortal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PagedList;
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
            
            sjovm.JobOfferViewModel = jobsOffer.ToPagedList(10,5);

            return View("AllOfers", sjovm);
        }

        [HttpGet]
        public async Task<ActionResult> HomeSearch(IndexHomeViewModel isjvm)
        {
            var jobsOffer = await _jobOfferService.JobSearchingAsync(isjvm.IndexSearchJobOfferViewModel.CitySearch, isjvm.IndexSearchJobOfferViewModel.PhraseSearch);

            var sjovm = new SearchJobOfferViewModel();
            var scvmn = new SearchConsoleViewModel();

            scvmn.JobCategoriesViewModel = await _jobCategoryService.GetAllJobCategoriesAsync();
            scvmn.CountryViewModel = await _countryService.GetAllCountriesAsync();
           
            sjovm.SearchConsoleViewModel = scvmn;

            sjovm.JobOfferViewModel = jobsOffer.ToPagedList(1, 5);
          

            return View("AllOfers", sjovm);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var jobOffer = await _jobOfferService.GetJobOfferByIdAsync(id);
            return View(jobOffer);
        }
         
        public async Task<ActionResult> AllOfers(int? page)
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);

            var jobOffers = await _jobOfferService.GetAllJobOfferAsync();

            var sjovm = new SearchJobOfferViewModel();
            var scvm = new SearchConsoleViewModel();
            scvm.JobCategoriesViewModel = await _jobCategoryService.GetAllJobCategoriesAsync();
            scvm.CountryViewModel = await _countryService.GetAllCountriesAsync();
            sjovm.SearchConsoleViewModel = scvm;

            var getJobs = await _jobOfferService.GetAllJobOfferAsync();

            sjovm.JobOfferViewModel = getJobs.ToPagedList(pageNumber, pageSize);



            return View(sjovm);
        }


        public async Task<ActionResult> DetailsCopy()
        {
            return View();
        }

    }
}