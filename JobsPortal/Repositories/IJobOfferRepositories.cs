using JobsPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsPortal.Repositories
{
    public interface IJobOfferRepositories
    {
        Task AddJobOfferAsync(JobOfferViewModel jobOffer);

        Task GetAsync(int id);
       
    }
}
