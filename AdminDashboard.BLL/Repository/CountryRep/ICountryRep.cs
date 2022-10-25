using AdminDashboard.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdminDashboard.BLL.Repository.CountryRep
{
    public interface ICountryRep
    {
        IEnumerable<Country> Get(Expression<Func<Country, bool>> filter = null);

    }
}
