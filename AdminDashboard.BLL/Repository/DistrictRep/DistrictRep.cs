using AdminDashboard.DAL.Database;
using AdminDashboard.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdminDashboard.BLL.Repository.DistrictRep
{
    public class DistrictRep : IDistrictRep
    {
        private readonly AdminDashboardContext db;

        public DistrictRep(AdminDashboardContext db)
        {
            this.db = db;
        }
        public IEnumerable<District> Get(Expression<Func<District, bool>> filter = null)
        {
            if (filter == null)
            {
                var Data = db.District.Select(x => x);
                return Data;
            }
            else
            {
                var Data = db.District.Where(filter);
                return Data;
            }
        }
    }
}
