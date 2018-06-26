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
        private readonly IStateService _stateService;
        private readonly IEmailService _emailService;

        public JobOfferController(IJobOfferService jobOfferService, IJobCategoryService jobCategoryService,
            ICountryService countryService, IStateService stateService, IEmailService emailService)
        {
            _emailService = emailService;
            _stateService = stateService;
            _jobCategoryService = jobCategoryService;
            _countryService = countryService;
            _jobOfferService = jobOfferService;
        }

        [HttpPost]
        public ActionResult SendApplications(ApplyJobOfferViewModel ajvm)
        {
            if (ModelState.IsValid)
            {
                var testEmail = "daniel.bednarczuk90@gmail.com";
                var message = ajvm.Name + " " + ajvm.Surname;
                _emailService.SendEmail(testEmail,message, ajvm.CvFile);
            }
           
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ColumnSearch(ColumnSearchConsoleViewModel scvm, int? page)
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);

          
            var selectedCategory = scvm.CategoriesViewModel.Where(x => x.IsChecked).ToList();

            var allJobs = await _jobOfferService.GetAllJobOfferAsync();

            allJobs = allJobs.ToList();

            var result = allJobs.Where(p => selectedCategory.Any(p2 => p2.Id == p.JobCategoriesId)).ToList();





            scvm.SearchConsoleViewModel.JobCategoriesViewModel = await _jobCategoryService.GetAllJobCategoriesAsync();
            scvm.SearchConsoleViewModel.CountryViewModel = await _countryService.GetAllCountriesAsync();
            scvm.SearchConsoleViewModel.StateViewModel = await _stateService.GetAllStatesAsync();

            

            return View("AllOfers", scvm);
        }

        [HttpPost]
        public async Task<ActionResult> HomeSearch(IndexSearchJobOfferViewModel scvm, int? page)
        {
           

           int pageSize = 8;
           int pageNumber = (page ?? 1);

            SearchJobOfferViewModel sjovm = new SearchJobOfferViewModel();
            sjovm.IndexSearchJobOfferViewModel = new IndexSearchJobOfferViewModel();
            sjovm.ColumnSearchConsoleViewModel = new ColumnSearchConsoleViewModel();
            sjovm.ColumnSearchConsoleViewModel.SearchConsoleViewModel = new SearchConsoleViewModel();

            sjovm.ColumnSearchConsoleViewModel.SearchConsoleViewModel.CountryViewModel = await _countryService.GetAllCountriesAsync();
            sjovm.ColumnSearchConsoleViewModel.SearchConsoleViewModel.StateViewModel = await _stateService.GetAllStatesAsync();

            sjovm.ColumnSearchConsoleViewModel.CategoriesViewModel = await _jobCategoryService.GetAllJobCategoriesAsync();
            sjovm.IndexSearchJobOfferViewModel = scvm;


            IEnumerable<JobOfferViewModel> jobsOffer = Enumerable.Empty<JobOfferViewModel>();
            jobsOffer = await _jobOfferService.JobSearchingAsync(scvm.CitySearch, scvm.PhraseSearch);

            sjovm.JobOfferViewModel = jobsOffer.ToPagedList(pageNumber, pageSize);


            return View("AllOfers", sjovm);


          
        }
        
        [HttpPost]
        public async Task<ActionResult> JobSearch(SearchJobOfferViewModel scvm, int ? page)
        {

            int pageSize = 8;
            int pageNumber = (page ?? 1);

            scvm.ColumnSearchConsoleViewModel = new ColumnSearchConsoleViewModel();
            var selectedCategory = scvm.ColumnSearchConsoleViewModel.CategoriesViewModel.Where(x => x.IsChecked == true);

                       

            IEnumerable<JobOfferViewModel> jobsOffer = Enumerable.Empty<JobOfferViewModel>();
            
            /*
            if(scvm.SearchConsoleViewModel.phraseSearch != "" && scvm.SearchConsoleViewModel.citySearch != "")
            {
                  jobsOffer = await _jobOfferService.JobSearchingAsync(scvm.SearchConsoleViewModel.citySearch, scvm.SearchConsoleViewModel.phraseSearch);
            }
            */

            scvm.SearchConsoleViewModel.JobCategoriesViewModel = await _jobCategoryService.GetAllJobCategoriesAsync();
            scvm.SearchConsoleViewModel.CountryViewModel = await _countryService.GetAllCountriesAsync();
            scvm.SearchConsoleViewModel.StateViewModel = await _stateService.GetAllStatesAsync();
          
            scvm.ColumnSearchConsoleViewModel.CategoriesViewModel = await _jobCategoryService.GetAllJobCategoriesAsync();

            scvm.JobOfferViewModel = jobsOffer.ToPagedList(pageNumber, pageSize);

            return View("AllOfers", scvm);
        }

        [HttpGet]
        [ActionName("JobSearchOverload")]
        public async Task<ActionResult> JobSearch(string city, string phrase , int? page, int? categoryId, int? countryId, int? regionId )
        {

            int pageSize = 8;
            int pageNumber = (page ?? 1);

            IEnumerable<JobOfferViewModel> jobsOffer = Enumerable.Empty<JobOfferViewModel>();

            if (phrase!= "" && city != "")
            {
                jobsOffer = await _jobOfferService.JobSearchingAsync(city, phrase);
            }
            SearchJobOfferViewModel sjovm = new SearchJobOfferViewModel();
            sjovm.SearchConsoleViewModel = new SearchConsoleViewModel();            
            sjovm.SearchConsoleViewModel.JobCategoriesViewModel = await _jobCategoryService.GetAllJobCategoriesAsync();
            sjovm.SearchConsoleViewModel.CountryViewModel = await _countryService.GetAllCountriesAsync();
            sjovm.SearchConsoleViewModel.citySearch = city;
            sjovm.SearchConsoleViewModel.phraseSearch = phrase;
            sjovm.SearchConsoleViewModel.selectedCategory = Convert.ToInt16(categoryId);

            sjovm.JobOfferViewModel = jobsOffer.ToPagedList(pageNumber, pageSize);

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
            var jobApplyViewModel = new JobApplyViewModel();
            jobApplyViewModel.JobOfferViewModel = await _jobOfferService.GetJobOfferByIdAsync(id);
            jobApplyViewModel.ApplyJobOfferViewModel = new ApplyJobOfferViewModel();
            return View(jobApplyViewModel);
        }
         
        public async Task<ActionResult> AllOfers(int? page)
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);

            var jobOffers = await _jobOfferService.GetAllJobOfferAsync();

            var sjovm = new SearchJobOfferViewModel();
            sjovm.ColumnSearchConsoleViewModel = new ColumnSearchConsoleViewModel();
            sjovm.ColumnSearchConsoleViewModel.SearchConsoleViewModel = new SearchConsoleViewModel();
            sjovm.ColumnSearchConsoleViewModel.SearchConsoleViewModel.JobCategoriesViewModel = await _jobCategoryService.GetAllJobCategoriesAsync();
            sjovm.ColumnSearchConsoleViewModel.SearchConsoleViewModel.CountryViewModel = await _countryService.GetAllCountriesAsync();
            sjovm.ColumnSearchConsoleViewModel.SearchConsoleViewModel.StateViewModel = await _stateService.GetAllStatesAsync(); 
         

            sjovm.ColumnSearchConsoleViewModel.CategoriesViewModel = await _jobCategoryService.GetAllJobCategoriesAsync();

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