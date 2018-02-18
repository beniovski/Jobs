using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace JobsPortal.Models
{
    public class JobOffer
    {
        public int Id { get; set; }

        public string CompanyId { get; set; }

        public int JobCategoriesId { get; set; }

        public string Title { get; set; }
      
        public string Country { get; set; }
      
        public string City { get; set; }
      
        public string Descriptions { get; set; }

        public string Requaierments { get; set; }
    
        public string Category { get; set; }
       
        [DataType(DataType.Date)]
        public DateTime? DateFrom { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateTo { get; set; }

        public Decimal SalaryMin { get; set; }

        public Decimal SalaryMax { get; set; }

        public bool IsActive { get; set; }

        public JobCategories JobCategories { get; set; } 

        public Countries Countries { get; set; }

        public ApplicationUser Company { get; set; }


    }

   


}