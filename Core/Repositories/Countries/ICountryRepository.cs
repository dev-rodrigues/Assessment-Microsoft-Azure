using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.Countries {
    public interface ICountryRepository {
        IQueryable<Country> Index();
        Country Show(int id);
        Country Store(Country model);
        Country Update(Country model);
    }
}