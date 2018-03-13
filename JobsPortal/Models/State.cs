using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobsPortal.Models
{
    public class State
    {
        
        public int Id { get; set; }

        public string StateName { get; set; }

        public HashSet<JobOffer> JobOffer;

        public State()
        {
            JobOffer = new HashSet<JobOffer>();
        }
    }
}