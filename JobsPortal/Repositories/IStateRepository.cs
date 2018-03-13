using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using JobsPortal.Models;

namespace JobsPortal.Repositories
{
    public interface IStateRepository
    {
        Task<IEnumerable<State>> GetAllStates();
    }
}