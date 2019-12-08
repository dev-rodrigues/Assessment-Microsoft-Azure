using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Territory.Countries;
using db = Application.Database.Database;

namespace Application.Repository.Territory.Countries {
    public class CountryRepository : ICountry {

        public async Task<bool> Delete(Country country) {
            try {
                db.GetInstance.Countries.Remove(country);
                await db.GetInstance.SaveChangesAsync();
                return true;
            } catch(Exception e) {
                Console.WriteLine(e.Message);
                return false;
            }
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

        public async Task<Country> Update(Country country) {
            try {
                db.GetInstance.Entry<Country>(country).State = EntityState.Modified;
                await db.GetInstance.SaveChangesAsync();
                return country;
            } catch(Exception e) {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
