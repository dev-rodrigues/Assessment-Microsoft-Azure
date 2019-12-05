using Core.Models;
using Core.Service.Countries;
using Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository {
    public class CountryRepository : ICountry {
        public Task<Country> BuscarPorId(int id) {
            throw new NotImplementedException();
        }

        public Task Deletar(int id) {
            throw new NotImplementedException();
        }

        public Task<Country> Editar(Country old) {
            throw new NotImplementedException();
        }

        public Task<List<Country>> Listar() {
            throw new NotImplementedException();
        }

        public async Task<Country> Salvar(Country country) {
            try {
                Database.GetContext.Countries.Add(country);
                await Database.GetContext.SaveChangesAsync();
                return country;
            } catch(Exception e) {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
