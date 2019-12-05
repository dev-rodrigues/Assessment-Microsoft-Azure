using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service.Countries {
    public interface ICountry {
        Task<Country> Save(Country obj);

        Task<Country> Update(Country old);

        Task Delete(int id);

        Task<Country> Find(int id);

        Task<List<Country>> FindAll(int id);
    }
}
