using AdminDashboard.DAL.Database;
using AdminDashboard.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdminDashboard.BLL.Repository.CountryRep
{
    public class CountryRep : ICountryRep
    {
        private readonly AdminDashboardContext db;

        public CountryRep(AdminDashboardContext db)
        {
            this.db = db;
        }
        public IEnumerable<Country> Get(Expression<Func<Country, bool>> filter = null)
        {
            if (filter == null)
            {
                var Data = db.Country.Select(x => x);
                return Data;
            }
            else
            {
                var Data = db.Country.Where(filter); 
                return Data;
            }
        }
    }
}
