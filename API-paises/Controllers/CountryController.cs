using API_PAISES.Models.InputModel;
using API_PAISES.Models.OutputModel;
using Core;
using Core.Models;
using Core.Service;
using Core.Service.Countries;
using Data.Repository;
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

        private ICountry GetCountry = ServiceLocator.GetInstanceOf<CountryRepository>();

        [HttpGet]
        public async Task<IHttpActionResult> Index() {
            var countries = await GetCountry.Listar();
            if(countries != null) {
                var converted = new OutputCountryModel().countries(countries);
                return Ok(converted);
            }
            return BadRequest("Erro ao processar a solicitação");
        }

        [HttpGet]
        public async Task<IHttpActionResult> Show(int id) {
            var localized_country = await GetCountry.BuscarPorId(id);
            if(localized_country != null) {
                var converted_country = new OutputCountryModel().country(localized_country);
                return Ok(converted_country);
            }
            return BadRequest("Erro ao processar a solicitação");
        }

        [HttpPost]
        public async Task<IHttpActionResult> Store(InputCountryModel input) {
            var country = new InputCountryModel().CreateCountry(input);
            var saved_country = await GetCountry.Salvar(country);
            var output_saved_country = new OutputCountryModel().country(saved_country);

            if(saved_country != null) {
                return CreatedAtRoute("DefaultApi", new { id = output_saved_country.Id }, output_saved_country);
            }
            return BadRequest("Erro ao processar a solicitação");
        }

        [HttpPut]
        public async Task<IHttpActionResult> Update(int id, InputCountryModel input) {
            var localized_country = await GetCountry.BuscarPorId(id);
            var updated_country = await GetCountry.Editar(localized_country);

            if(updated_country != null) {
                var output_updated_country = new OutputCountryModel().country(updated_country);
                return Ok(output_updated_country);
            }
            return BadRequest("Erro ao processar a solicitação");
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Destroy(int id) {
            await GetCountry.Deletar(id);
            return Ok();
        }
    }
}