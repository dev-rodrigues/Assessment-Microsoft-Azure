using Application.Repository.Territory.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service {
    public class Locator {
        private static Dictionary<Type, Type> Country = new Dictionary<Type, Type> {
            [typeof(ICountry)] = typeof(CountryRepository)
        };

        public static T GetInstanceOf<T>() {
            return Activator.CreateInstance<T>();
        }
    }
}
