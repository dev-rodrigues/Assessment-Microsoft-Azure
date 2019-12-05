using API_estados.Models.InputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_estados.Controllers {
    [RoutePrefix("api/estado")]
    public class StateController : ApiController {
        [HttpGet]
        public IHttpActionResult Index() {
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult Show(int id) {
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Store(InputEstadoModel input) {
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Update(InputEstadoModel input) {
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Destroy(int id) {
            return Ok();
        }
    }
}
