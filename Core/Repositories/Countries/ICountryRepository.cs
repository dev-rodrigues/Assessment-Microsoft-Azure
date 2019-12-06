using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.Countries {
    public interface ICountryRepository {
        List<Country> Index(Country model);
        Country Show(Country model, int id);
        Country Store(Country model);
        Country Update(Country model);
    }
}