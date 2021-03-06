﻿using AutoMapper;
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
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<JobOffer, AddJobOfferViewModel>();
                cfg.CreateMap<AddJobOfferViewModel, JobOffer>()
                    .ForMember(dest => dest.JobCategories, opts => opts.MapFrom(src => src.JobCategoriesViewModel))
                    .ForMember(dest => dest.Countries, opts => opts.MapFrom(src => src.CountryViewModel))
                    .ForMember(dest => dest.State, opts => opts.MapFrom(src => src.StateViewModel))
                    .ForMember(dest => dest.City, opts => opts.MapFrom(src => src.JobOfferViewModel.City))
                    .ForMember(dest => dest.Company, opts => opts.MapFrom(src => src.JobOfferViewModel.Company))
                    .ForMember(dest => dest.CompanyId, opts => opts.MapFrom(src => src.JobOfferViewModel.CompanyId))
                    .ForMember(dest => dest.DateFrom, opts => opts.MapFrom(src => src.JobOfferViewModel.DateFrom))
                    .ForMember(dest => dest.DateTo, opts => opts.MapFrom(src => src.JobOfferViewModel.DateTo))
                    .ForMember(dest => dest.Descriptions, opts => opts.MapFrom(src => src.JobOfferViewModel.Descriptions))
                    .ForMember(dest => dest.JobCategoriesId, opts => opts.MapFrom(src => src.JobOfferViewModel.JobCategories.Id))
                    .ForMember(dest => dest.CountriesId, opts => opts.MapFrom(src => src.JobOfferViewModel.Country.Id))
                    .ForMember(dest => dest.StateId, opts => opts.MapFrom(src => src.JobOfferViewModel.State.Id))
                    .ForMember(dest => dest.Requaierments, opts => opts.MapFrom(src => src.JobOfferViewModel.Requaierments))
                    .ForMember(dest => dest.SalaryMax, opts => opts.MapFrom(src => src.JobOfferViewModel.SalaryMax))
                    .ForMember(dest => dest.SalaryMin, opts => opts.MapFrom(src => src.JobOfferViewModel.SalaryMin))
                    .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.JobOfferViewModel.Title))
                    .ForMember(dest => dest.IsActive, opts => opts.MapFrom(src => src.JobOfferViewModel.IsActive))
                ;

                cfg.CreateMap<JobCategoriesViewModel, JobCategories>();
                cfg.CreateMap<JobCategories, JobCategoriesViewModel>();
                cfg.CreateMap<CountryViewModel, Countries>();
                cfg.CreateMap<Countries, CountryViewModel>();
                cfg.CreateMap<StateViewModel, State>();
                cfg.CreateMap<State, StateViewModel>();
                cfg.CreateMap< EditJobOfferViewModel , JobOffer>();

            });

        }
    }
}