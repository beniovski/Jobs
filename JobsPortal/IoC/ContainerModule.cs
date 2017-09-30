﻿using Autofac;
using JobsPortal.Repositories;
using JobsPortal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobsPortal.IoC
{
    public class ContainerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<JobOfferService>().As<IJobOfferService>();
            builder.RegisterType<JobRepository>().As<IJobOfferRepositories>();

            base.Load(builder);

        }
    }
}