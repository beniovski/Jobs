using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using JobsPortal.Models;

namespace JobsPortal.Repositories
{
    public class StateRepository : DbConnection, IStateRepository
    {
        public async  Task<IEnumerable<State>> GetAllStates()
        {
            return _dbContext.State;
        }
    }
}