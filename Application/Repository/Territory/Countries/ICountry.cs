using Application.Models.Territory.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Territory.Countries {
    public interface ICountry {
        Task<Country> Save(Country country);
        Task<Country> Update(Country country);
        Task<bool> Delete(Country country);
        Task<Country> Find(int id_country);
        List<Country> Index();
    }
}
