using MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers {
    public class HomeController : Controller {
        private readonly string base_url_amigo = "http://localhost:52353";
        public async Task<ActionResult> Index() {
            var resultado = new OutputSomatorioModel();

            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri(base_url_amigo);
                var response = await client.GetAsync("api/Count");

                if(response.IsSuccessStatusCode) {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    resultado = JsonConvert.DeserializeObject<OutputSomatorioModel>(responseContent);
                    ViewBag.SomatorioUsuario = resultado.SumFriend;
                    ViewBag.SomatorioPais = resultado.SumCountry;
                    ViewBag.SomatorioEstado = resultado.SumState;
                    return View();
                }
            }
            return View("Error");
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}