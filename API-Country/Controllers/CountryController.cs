﻿using API_PAISES.Models.InputModel;
using API_PAISES.Models.OutputModel;
using Application.Repository.Territory.Countries;
using Application.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.UI.WebControls;

namespace API_PAISES.Controllers {

    [RoutePrefix("api/Country")]
    public class CountryController : ApiController {

        private ICountry GetCountryRepository { get; }

        public CountryController() {
            GetCountryRepository = Locator.GetInstanceOf<CountryRepository>();
        }

        //[HttpGet]
        //public IHttpActionResult Index() {

        //    var countries = GetCountryRepository.Index().ToList<Country>();

        //    if(countries != null) {
        //        var converted = new OutputCountryModel().countries(countries);
        //        return Ok(converted);
        //    }
        //    return BadRequest("Erro ao processar a solicitação");
        //}

        [HttpGet]
        public async Task<IHttpActionResult> Show(int id) {
            var localized_country = await GetCountryRepository.Find(id);
            if(localized_country != null) {
                var converted_country = new OutputCountryModel().country(localized_country);
                return Ok(converted_country);
            }
            return BadRequest("Erro ao processar a solicitação.");
        }

        //[HttpGet]
        //public IHttpActionResult Show(string name) {
        //    var localized_country = GetCountryRepository.Show(name);
        //    if(localized_country != null) {
        //        var converted_country = new OutputCountryModel().country(localized_country);
        //        return Ok(converted_country);
        //    }
        //    return BadRequest("Erro ao processar a solicitação.");
        //}

        [HttpPost]
        public async Task<IHttpActionResult> Store(InputCountryModel input) {
            var new_country = new InputCountryModel().CreateCountry(input);
            var saved_country = await GetCountryRepository.Save(new_country);

            var output_saved_country = new OutputCountryModel().country(saved_country);

            if(saved_country != null) {
                return CreatedAtRoute("DefaultApi", new { id = output_saved_country.Id }, output_saved_country);
            }
            return BadRequest("Erro ao processar a solicitação");
        }

        //[HttpPut]
        //public IHttpActionResult Update(int id, InputCountryModel input) {
        //    var localized_country = GetCountryRepository.Show(id);
        //    localized_country.Name = input.Name;
        //    localized_country.URLImage = input.IdImage;

        //    var updated_country = GetCountryRepository.Update(localized_country);

        //    if(updated_country != null) {
        //        var output_updated_country = new OutputCountryModel().country(updated_country);
        //        return Ok(output_updated_country);
        //    }
        //    return BadRequest("Erro ao processar a solicitação");
        //}

        //[HttpDelete]
        //public IHttpActionResult Destroy(int id) {
        //    var localized_country = GetCountryRepository.Show(id);
        //    if(localized_country != null) {
        //        GetCountryRepository.Delete(localized_country);
        //        return Ok();
        //    }
        //    return BadRequest();
        //}
    }
}