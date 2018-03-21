﻿using JobsPortal.Services;
using JobsPortal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

namespace JobsPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJobOfferService _jobOfferService;

        public HomeController(IJobOfferService jobOfferService)
        {
            _jobOfferService = jobOfferService;
        }
        public async Task<ActionResult> Index()
        {
            var jobOffer = await _jobOfferService.GetAllJobOfferAsync();

            IndexHomeViewModel ihvm = new IndexHomeViewModel();
            ihvm.JobOfferViewModel = jobOffer.OrderByDescending(x => x.DateFrom).Take(10);

            return View(ihvm);
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
       

        public JsonResult MainSearch(string term)
        {
           return Json(_jobOfferService.JobSuggestBoxSearch(term), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CitySuggest(string term)
        {
            return Json(_jobOfferService.CitySuggestBox(term), JsonRequestBehavior.AllowGet);
        }
    }
}