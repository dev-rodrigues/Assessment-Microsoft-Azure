using Core.Models;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.Countries {
    public class CountryRepository : RepositoryBase<Country>, ICountryRepository {
        public IQueryable<Country> Index() {
            var lista = from p in base.FindAll() select p;
            return lista;
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
