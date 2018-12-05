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
using System.Web.Security;
using System.Web.Caching;
using Microsoft.AspNet.Identity.Owin;

namespace JobsPortal.Controllers
{
    public class JobOfferController : Controller
    {
        private readonly IJobOfferService _jobOfferService;
        private readonly IJobCategoryService _jobCategoryService;
        private readonly ICountryService _countryService;
        private readonly IStateService _stateService;
        private readonly IEmailService _emailService;
        private readonly ICacheService _cacheService;

        public JobOfferController(IJobOfferService jobOfferService, IJobCategoryService jobCategoryService,
            ICountryService countryService, IStateService stateService, IEmailService emailService, ICacheService cacheService)
        {
            _emailService = emailService;
            _stateService = stateService;
            _jobCategoryService = jobCategoryService;
            _countryService = countryService;
            _jobOfferService = jobOfferService;
            _cacheService = cacheService;
        }

        [HttpPost]
        public ActionResult SendApplications(ApplyJobOfferViewModel ajvm)
        {
            
            if (ModelState.IsValid)
            {
                var email = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(ajvm.CompanyId).UserName;
                var message = ajvm.Name + " " + ajvm.Surname;
                _emailService.SendEmail(email, message, ajvm.CvFile);
            }
           
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ColumnSearch(ColumnSearchConsoleViewModel scvm, int? page)
        {          
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            var sjvm = await SjovmBulider();
            var selectedStates = scvm.StateVievModel.Where(x => x.IsChecked).ToList();               
            var selectedCategory = scvm.CategoriesViewModel.Where(x => x.IsChecked).ToList();
            var getjobs = await _jobOfferService.ColumnSearchAsync(selectedCategory, selectedStates, scvm.AbroadSearch);
            _cacheService.SetCache("jobOffer", getjobs);
            sjvm.JobOfferViewModel = getjobs.ToPagedList(pageNumber, pageSize);            
            sjvm.SearchType = "ColumnSearch"; 
            return View("AllOfers", sjvm);
        }

        [HttpGet]
        public async Task<ActionResult> ColumnSearch(int ? page) 
        {
            int pageNumber = (page ?? 1);  
            int pageSize = 8;
            var sjvm = await SjovmBulider();
            var getjobs = _cacheService.GetFromCache<IEnumerable<JobOfferViewModel>>("jobOffer");
            sjvm.JobOfferViewModel = getjobs.ToPagedList(pageNumber, pageSize);    
            sjvm.SearchType = "ColumnSearch";
            return View("AllOfers", sjvm);
        }

        [HttpPost]
        public async Task<ActionResult> HomeSearch(MainSearchConsoleViewModel scvm)
        {                        
            int pageSize = 8;
            int pageNumber = 1;
            var sjovm = await SjovmBulider();
            sjovm.MainSearchConsoleViewModel = scvm;
            sjovm.SearchType = "HomeSearch";            
            var jobsOffer = await _jobOfferService.JobSearchingAsync(scvm.CitySearch, scvm.PhraseSearch);
            _cacheService.SetCache("HomeSearchJobCache", jobsOffer);
            sjovm.JobOfferViewModel = jobsOffer.ToPagedList(pageNumber, pageSize);
            return View("AllOfers", sjovm);          
        }    

        [HttpGet]
        public async Task<ActionResult> HomeSearch(int ? page) 
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            var sjovm = await SjovmBulider();
            var jobsOffer = _cacheService.GetFromCache<IEnumerable<JobOfferViewModel>>("HomeSearchJobCache");
            sjovm.SearchType = "HomeSearch";
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
            scvm.SearchConsoleViewModel.JobCategoriesViewModel = await _jobCategoryService.GetAllJobCategoriesAsync();
            scvm.SearchConsoleViewModel.CountryViewModel = await _countryService.GetAllCountriesAsync();             
            scvm.ColumnSearchConsoleViewModel.CategoriesViewModel = await _jobCategoryService.GetAllJobCategoriesAsync();
            scvm.ColumnSearchConsoleViewModel.StateVievModel = await _stateService.GetAllStatesAsync();
            scvm.JobOfferViewModel = jobsOffer.ToPagedList(pageNumber, pageSize);
            return View("AllOfers", scvm);
        }

        public async Task<ActionResult> AllOfers(int? page, string searchType = "")
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);

            var jobOffers = await _jobOfferService.GetAllJobOfferAsync();

            var sjovm = new SearchJobOfferViewModel();
            sjovm.ColumnSearchConsoleViewModel = new ColumnSearchConsoleViewModel();
            sjovm.ColumnSearchConsoleViewModel.SearchConsoleViewModel = new SearchConsoleViewModel();
            sjovm.MainSearchConsoleViewModel = new MainSearchConsoleViewModel();
            sjovm.ColumnSearchConsoleViewModel.SearchConsoleViewModel.JobCategoriesViewModel = await _jobCategoryService.GetAllJobCategoriesAsync();
            sjovm.ColumnSearchConsoleViewModel.SearchConsoleViewModel.CountryViewModel = await _countryService.GetAllCountriesAsync();
            sjovm.ColumnSearchConsoleViewModel.StateVievModel = await _stateService.GetAllStatesAsync();


            sjovm.ColumnSearchConsoleViewModel.CategoriesViewModel = await _jobCategoryService.GetAllJobCategoriesAsync();

            var getJobs = await _jobOfferService.GetAllJobOfferAsync();

            sjovm.JobOfferViewModel = getJobs.ToPagedList(pageNumber, pageSize);



            return View(sjovm);
        }


        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var jobApplyViewModel = new JobApplyViewModel();
            jobApplyViewModel.JobOfferViewModel = await _jobOfferService.GetJobOfferByIdAsync(id);
            jobApplyViewModel.ApplyJobOfferViewModel = new ApplyJobOfferViewModel();
            return View(jobApplyViewModel);
        }      

        public async Task<ActionResult> DetailsCopy()
        {
            return View();
        }


        private async Task<SearchJobOfferViewModel> SjovmBulider()
        {
            SearchJobOfferViewModel sjovm = new SearchJobOfferViewModel();
            sjovm.MainSearchConsoleViewModel = new MainSearchConsoleViewModel();
            sjovm.ColumnSearchConsoleViewModel = new ColumnSearchConsoleViewModel();
            sjovm.ColumnSearchConsoleViewModel.SearchConsoleViewModel = new SearchConsoleViewModel();
            sjovm.ColumnSearchConsoleViewModel.SearchConsoleViewModel.CountryViewModel = await _countryService.GetAllCountriesAsync();
            sjovm.ColumnSearchConsoleViewModel.StateVievModel = await _stateService.GetAllStatesAsync();
            sjovm.ColumnSearchConsoleViewModel.CategoriesViewModel = await _jobCategoryService.GetAllJobCategoriesAsync();
            return sjovm;
        }

    }
}