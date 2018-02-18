using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using JobsPortal.Models;

namespace JobsPortal.Repositories
{
    public interface ICountryRepository
    {
         Task<IEnumerable<Countries>> GetAllCountriesAsync();
    }
}