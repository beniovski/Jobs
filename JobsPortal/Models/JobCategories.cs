using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobsPortal.Models
{
    public class JobCategories
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public HashSet<JobOffer> JobOffer;

        public JobCategories()
        {
            JobOffer = new HashSet<JobOffer>();
        }
    }
}