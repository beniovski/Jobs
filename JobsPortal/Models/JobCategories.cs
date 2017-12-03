using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobsPortal.Models
{
    public class JobCategories
    {
        public int id { get; set; }

        public string name { get; set; }

        HashSet<JobOffer> JobOffer;

        public JobCategories()
        {
            JobOffer = new HashSet<JobOffer>();
        }
    }
}