using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Territory.Countries;
using db = Application.Database.Database;

namespace Application.Repository.Territory.Countries {
    public class CountryRepository : ICountry {
        public Task<bool> Delete(Country country) {
            throw new NotImplementedException();
        }

        public async Task<Country> Find(int id_country) {
            try {
                return await db.GetInstance.Countries.FindAsync(id_country);
            } catch(Exception e) {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<Country> Index() {
            return db.GetInstance.Countries.ToList();
        }

        public async Task<Country> Save(Country country) {
            try {
                db.GetInstance.Countries.Add(country);
                await db.GetInstance.SaveChangesAsync();
                return country;
            } catch(Exception e) {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public Task<Country> Update(Country country) {
            throw new NotImplementedException();
        }
    }
}
