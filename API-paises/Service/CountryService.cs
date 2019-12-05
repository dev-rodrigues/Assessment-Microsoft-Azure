using Core.Service.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_PAISES.Service {
    public class CountryService {
        private CountryRepository GetCountryRepository { get; set; }

        public CountryService() {
            this.GetCountryRepository = new CountryRepository();
        }


    }
}