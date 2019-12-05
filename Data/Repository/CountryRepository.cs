using Core.Models;
using Core.Service.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository {
    public class CountryRepository : ICountry {
        public Task Deletar(int id) {
            throw new NotImplementedException();
        }

        public Task<Country> Editar(Country old) {
            throw new NotImplementedException();
        }

        public Task<List<Country>> Listar() {
            throw new NotImplementedException();
        }

        public Task<Country> Salvar(Country country) {
            throw new NotImplementedException();
        }
    }
}
