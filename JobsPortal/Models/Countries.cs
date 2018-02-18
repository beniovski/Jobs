using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobsPortal.Models
{
    public class Countries
    {
        public int Id { get; set; }

        public string CountryName { get; set; }

        public HashSet<JobOffer> JobOffer;

        public Countries()
        {
            JobOffer = new HashSet<JobOffer>();
        }
    }
}