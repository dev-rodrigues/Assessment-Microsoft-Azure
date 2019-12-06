using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.Countries {
    public interface ICountryRepository {
        Country Store(Country model);
        Country Update(Country model);
        bool Delete(Country model);
        Country Show(object id);
        List<Country> Index(Country model);
    }
}
