using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace JobsPortal.Models
{
    public class JobOffer
    {
        public int Id { get; set; }

        public string Title { get; set; }
      
        public string Country { get; set; }
      
        public string City { get; set; }
      
        public string Descriptions { get; set; }

        public string Requaierments { get; set; }
    
        public string Category { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public DateTime DateFrom { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public DateTime DateTo { get; set; }

        public Decimal SalaryMin { get; set; }

        public Decimal SalaryMax { get; set; }

        public string CompanyId { get; set; }

        public string JobCategoryId { get; set; }

        public JobCategories JobCategories { get; set; }

        public ApplicationUser Company { get; set; }


    }

   


}