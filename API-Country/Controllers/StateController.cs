using API_PAISES.Models.InputModel;
using API_PAISES.Models.OutputModel;
using Core;
using Core.Models;
using Core.Models.State;
using Core.Repositories.Countries;
using Core.Repositories.States;
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

namespace API_Country.Controllers {

    [RoutePrefix("api/state")]
    public class StateController : ApiController {

        private StateRepository GetStateRepository { get; }

        public StateController() {
            this.GetStateRepository = new StateRepository();
        }

        [HttpGet]
        public IHttpActionResult Index() {

            var states = GetStateRepository.Index().ToList<State>();

            if(states != null) {
                var converted = new OutputStateModel().states(states);
                return Ok(converted);
            }
            return BadRequest("Erro ao processar a solicitação");
        }
    }
}