using API_Country.Models.OutputModel;
using API_estados.Models.InputModel;
using API_PAISES.Models.InputModel;
using Application.Repository.Territory.Countries;
using Application.Repository.Territory.States;
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

namespace API_Country.Controllers {

    [RoutePrefix("api/State")]
    public class StateController : ApiController {

        private IState GetStateRepository { get; set; }
        private ICountry GetCountryRepository { get; set; }

        public StateController() {
            this.GetStateRepository = Locator.GetInstanceOf<StateRepository>();
            this.GetCountryRepository = Locator.GetInstanceOf<CountryRepository>();
        }

        [HttpGet]
        public IHttpActionResult Index() {
            var states = GetStateRepository.Index();

            if(states != null) {
                var converted = new OutputSimpleStateModel().OutputStates(states);
                return Ok(converted);
            }
            return BadRequest("Erro ao processar a solicitação");
        }

        [HttpGet]
        public async Task<IHttpActionResult> Show(int id) {
            var localized_state = await GetStateRepository.Find(id);

            if(localized_state != null) {
                var converted_state = OutputStateModel.ConvertState(localized_state);
                return Ok(converted_state);
            }
            return BadRequest("Erro ao processar a solicitação.");
        }

        //[HttpPost]
        //public async Task<IHttpActionResult> Store(InputStateModel input) {
        //    var localized_country = await GetCountryRepository.Find(input.Id_Country);

        //    if(localized_country == null) {
        //        return BadRequest("País não informado");
        //    }

        //    var new_state = new InputStateModel().CreateState(input);
        //    new_state.Country = localized_country;

        //    //localized_country.States.Add(new_state);

        //    var saved_state = await GetStateRepository.Save(new_state);

        //    //GetCountryRepository.Update(localized_country);

        //    if(saved_state != null) {
        //        var output_saved_state = new OutputStateModel().state(saved_state);
        //        return CreatedAtRoute("DefaultApi", new { id = output_saved_state.Id }, output_saved_state);
        //    }
        //    return BadRequest("Erro ao processar a solicitação");
        //}

        //    [HttpPut]
        //    public IHttpActionResult Update(int id, InputStateModel input) {
        //        var localized_state = GetStateRepository.Show(id);
        //        localized_state.Name = input.Name;
        //        localized_state.URLImage = input.IdImage;

        //        var updated_state = GetStateRepository.Update(localized_state);

        //        if(updated_state != null) {
        //            var output_updated_country = new OutputStateModel().state(updated_state);
        //            return Ok(output_updated_country);
        //        }
        //        return BadRequest("Erro ao processar a solicitação");
        //    }

        //    [HttpDelete]
        //    public IHttpActionResult Destroy(int id) {
        //        var localized_state = GetStateRepository.Show(id);
        //        if(localized_state != null) {
        //            GetStateRepository.Delete(localized_state);
        //            return Ok();
        //        }
        //        return BadRequest();
        //    }
    }
}