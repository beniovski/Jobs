using JobsPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobsPortal.Repositories
{
    public abstract class DbConnection
    {
        protected readonly ApplicationDbContext _dbContext;

        protected DbConnection()
        {
            _dbContext = new ApplicationDbContext();
        }
    }
}