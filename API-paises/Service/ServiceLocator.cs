using Core.Service.Countries;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service {
    public class ServiceLocator {

        public static Dictionary<Type, Type> Country = new Dictionary<Type, Type> {
            [typeof(ICountry)] = typeof(CountryRepository)
        };

        internal static T GetInstanceOf<T>() {
            return Activator.CreateInstance<T>();
        }
    }
}
