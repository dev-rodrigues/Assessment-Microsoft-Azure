using MVC.Models;
using MVC.Models.edit;
using MVC.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers {
    public class EstadoController : Controller {
        private readonly string base_url = "http://localhost:54595";

        // GET: State
        [HttpGet]
        public async Task<ActionResult> Index() {
            var estados = new List<EstadoViewModel>();

            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri(base_url);

                var response = await client.GetAsync("api/State");

                if(response.IsSuccessStatusCode) {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    estados = JsonConvert.DeserializeObject<List<EstadoViewModel>>(responseContent);

                    return View(estados);
                }
            }

            return View("Error");
        }

        [HttpGet]
        public async Task<ActionResult> Create() {
            var paises = new List<PaisViewModel>();
            CreateEstadoViewModel estado = new CreateEstadoViewModel();
            bool pegouPaises = false;

            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri(base_url);

                var response = await client.GetAsync("api/Country");

                if(response.IsSuccessStatusCode) {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    paises = JsonConvert.DeserializeObject<List<PaisViewModel>>(responseContent);

                    estado.Paises = paises;

                    pegouPaises = true;
                }
            }

            if(pegouPaises)
                return View(estado);
            else
                return View("Error");

        }

        [HttpPost]
        public async Task<ActionResult> Create(FormCollection collection, HttpPostedFileBase foto) {

            if(foto != null) {
                string code_img = Guid.NewGuid().ToString();
                new UploadAzure().UploadDeArquivo(foto.InputStream, $"{code_img}.png");

                var data = new Dictionary<string, string>
                {
                    {"Name", collection["Estado.Name"]},
                    {"IdImage", code_img},
                    {"Id_Country", collection["paises"] }
                };

                using(var client = new HttpClient()) {
                    client.BaseAddress = new Uri(base_url);

                    using(var requestContent = new FormUrlEncodedContent(data)) {
                        var response = await client.PostAsync("api/State", requestContent);

                        if(response.IsSuccessStatusCode) {
                            return RedirectToAction("Index");
                        }
                    }
                }
            }
            return View("Error");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(string id) {
            EditEstadoViewModel EditEstado = new EditEstadoViewModel();
            bool pegouPaises = false;
            bool pegouEstado = false;

            // pegou paises
            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri(base_url);

                var response = await client.GetAsync("api/Country");

                if(response.IsSuccessStatusCode) {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    EditEstado.Paises = JsonConvert.DeserializeObject<List<PaisViewModel>>(responseContent);

                    pegouPaises = true;
                }
            }

            // pegou estado
            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri(base_url);

                var response = await client.GetAsync($"api/State/{id}");

                if(response.IsSuccessStatusCode) {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    EditEstado.Estado = JsonConvert.DeserializeObject<EstadoViewModel>(responseContent);

                    pegouEstado = true;
                }
            }

            if(pegouPaises && pegouEstado)
                return View(EditEstado);
            else
                return View("Error");

        }

        [HttpPost]
        public async Task<ActionResult> Edit(FormCollection collection, string id) {
            var data = new Dictionary<string, string>
            {
                {"Name", collection["EditEstado.Name"]},
                {"IdImage", collection["EditEstado.IdImage"]},
                {"Id_Country", collection["paises"] }
            };

            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri(base_url);

                using(var requestContent = new FormUrlEncodedContent(data)) {
                    var response = await client.PutAsync($"api/State/{id}", requestContent);

                    if(response.IsSuccessStatusCode) {
                        return RedirectToAction("Index");
                    } else {
                        return View();
                    }
                }
            }
        }

        [HttpGet]
        public async Task<ActionResult> Delete(string id) {
            EstadoViewModel estado = new EstadoViewModel();

            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri(base_url);

                var response = await client.GetAsync($"api/State/{id}");

                if(response.IsSuccessStatusCode) {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    estado = JsonConvert.DeserializeObject<EstadoViewModel>(responseContent);

                    return View(estado);
                }
            }

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id, FormCollection form) {
            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri(base_url);

                var response = await client.DeleteAsync($"api/State/{id}");

                if(response.IsSuccessStatusCode) {
                    return RedirectToAction("Index");
                } else {
                    return View();
                }
            }
        }

        [HttpGet]
        public async Task<ActionResult> Details(string id) {
            EstadoViewModel estado = new EstadoViewModel();

            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri(base_url);

                var response = await client.GetAsync($"api/State/{id}");

                if(response.IsSuccessStatusCode) {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    estado = JsonConvert.DeserializeObject<EstadoViewModel>(responseContent);

                    return View(estado);
                }
            }

            return View();
        }
    }
}