using API_PAISES.Models.InputModel;
using API_PAISES.Service;
using Core;
using Core.Models;
using Core.Repositories.Countries;
using Core.Service.Countries;
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

        public CountryController() {

        }

        [HttpGet]
        public IHttpActionResult Index() {
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult Show(int id) {
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Store(InputCountryModel input) {
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Update(InputCountryModel input) {
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Destroy(int id) {
            return Ok();
        }
    }
}