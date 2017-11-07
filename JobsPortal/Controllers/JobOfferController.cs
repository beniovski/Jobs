using JobsPortal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace JobsPortal.Controllers
{
    public class JobOfferController : Controller
    {
        private readonly IJobOfferService _jobOfferService;

        public JobOfferController(IJobOfferService jobOfferService)
        {
            _jobOfferService = jobOfferService;
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
            return View(jobOffers);
        }


        public async Task<ActionResult> DetailsCopy()
        {
            return View();
        }

    }
}