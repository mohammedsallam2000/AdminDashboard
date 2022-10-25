using AdminDashboard.DAL.Database;
using AdminDashboard.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdminDashboard.BLL.Repository.CityRep
{
   public class CityRep : ICityRep
    {
        private readonly AdminDashboardContext db;

        public CityRep(AdminDashboardContext db)
        {
            this.db = db;
        }
        public IEnumerable<City> Get(Expression<Func<City, bool>> filter = null)
        {
            if (filter == null)
            {
                var Data = db.City.Select(x => x);
                return Data;
            }
            else
            {
                var Data = db.City.Where(filter);
                return Data;
            }
        }
    }
}
