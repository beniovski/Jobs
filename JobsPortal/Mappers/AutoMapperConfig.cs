using AutoMapper;
using JobsPortal.Models;
using JobsPortal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobsPortal.Mappers
{
    public class AutoMapperConfig
    {
        public static void Init()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<JobOffer, AddJobOfferViewModel>();
                cfg.CreateMap<AddJobOfferViewModel, JobOffer>();
                cfg.CreateMap<JobCategoriesViewModel, JobCategories>();
                cfg.CreateMap<JobCategories, JobCategoriesViewModel>();

            });

        }
    }
}