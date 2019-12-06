using Core.Models;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.Countries {
    public class CountryRepository : RepositoryBase<Country>, ICountryRepository {
        public List<Country> Index(Country model) {
            return base.FindAll(model);
        }

        public Country Show(Country model, int id) {
            return base.Find(id);
        }

        public Country Store(Country model) {
            return base.Save(model);
        }

        public Country Update(Country model) {
            return base.Edit(model);
        }
    }
}
