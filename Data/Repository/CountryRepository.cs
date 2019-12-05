using Core.Models;
using Core.Service.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository {
    public class CountryRepository : ICountry {
        public Task Delete(int id) {
            throw new NotImplementedException();
        }

        public Task<Country> Find(int id) {
            throw new NotImplementedException();
        }

        public Task<List<Country>> FindAll(int id) {
            throw new NotImplementedException();
        }

        public Task<Country> Save(Country obj) {
            throw new NotImplementedException();
        }

        public Task<Country> Update(Country old) {
            throw new NotImplementedException();
        }
    }
}
