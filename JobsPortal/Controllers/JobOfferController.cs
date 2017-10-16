﻿using JobsPortal.Services;
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

        public async Task<ActionResult> Details(int id)
        {
            var jobOffer = await _jobOfferService.GetJobOfferByIdAsync(id);
            return View(jobOffer);
        }

    }
}