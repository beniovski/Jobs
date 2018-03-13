using Autofac;
using JobsPortal.Repositories;
using JobsPortal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac.Integration.Mvc;

namespace JobsPortal.IoC
{
    public class ContainerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<JobRepository>().As<IJobOfferRepositories>();
            builder.RegisterType<JobOfferService>().As<IJobOfferService>();
            builder.RegisterType<JobCategoriesRepository>().As<IJobCategoryRepository>();
            builder.RegisterType<CountryRepository>().As<ICountryRepository>();
            builder.RegisterType<StateRepository>().As<IStateRepository>();
            builder.RegisterType<JobCategoryService>().As<IJobCategoryService>();
            builder.RegisterType<CountryService>().As<ICountryService>();
            builder.RegisterType<StateService>().As<IStateService>();
            builder.RegisterType<EmailServices>().As<IEmailService>().InstancePerLifetimeScope();

            base.Load(builder);

        }
    }
}