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
    public class AmigoController : Controller {
        private readonly string base_url_amigo = "http://localhost:52353";
        private readonly string base_url_pais_estado = "http://localhost:54595";


        // GET: Country
        [HttpGet]
        public async Task<ActionResult> Index() {
            var amigos = new List<FriendViewModel>();

            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri(base_url_amigo);

                var response = await client.GetAsync("api/Friend");

                if(response.IsSuccessStatusCode) {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    amigos = JsonConvert.DeserializeObject<List<FriendViewModel>>(responseContent);

                    return View(amigos);
                }
            }

            return View("Error");
        }

        [HttpGet]
        public async Task<ActionResult> Create() {
            var paises = new List<PaisViewModel>();
            var estados = new List<EstadoViewModel>();
            CreateAmigoViewModel amigo = new CreateAmigoViewModel();
            bool pegouPaises = false;
            bool pegouEstados = false;

            // pega pais
            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri(base_url_pais_estado);

                var response = await client.GetAsync("api/Country");

                if(response.IsSuccessStatusCode) {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    paises = JsonConvert.DeserializeObject<List<PaisViewModel>>(responseContent);

                    amigo.Paises = paises;

                    pegouPaises = true;
                }
            }

            // pega estado
            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri(base_url_pais_estado);

                var response = await client.GetAsync("api/State");

                if(response.IsSuccessStatusCode) {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    estados = JsonConvert.DeserializeObject<List<EstadoViewModel>>(responseContent);

                    amigo.Estados = estados;

                    pegouEstados = true;
                }
            }

            if(pegouPaises && pegouEstados)
                return View(amigo);
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
                    {"Name", collection["Amigo.Name"]},
                    {"LastName", collection["Amigo.LastName"]},
                    {"Email", collection["Amigo.Email"]},
                    {"Telephone", collection["Amigo.Telephone"]},
                    {"BirthDate", collection["Amigo.BirthDate"]},
                    {"IdCountry", collection["paises"]},
                    {"IdState", collection["estados"]},
                };

                using(var client = new HttpClient()) {
                    client.BaseAddress = new Uri(base_url_amigo);

                    using(var requestContent = new FormUrlEncodedContent(data)) {
                        var response = await client.PostAsync("api/Friend", requestContent);

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
            EditAmigoViewModel EditAmigo = new EditAmigoViewModel();
            bool pegouPaises = false;
            bool pegouEstados = false;
            bool pegouUser = false;

            // pega paises
            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri(base_url_pais_estado);

                var response = await client.GetAsync("api/Country");

                if(response.IsSuccessStatusCode) {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    EditAmigo.Paises = JsonConvert.DeserializeObject<List<PaisViewModel>>(responseContent);

                    pegouPaises = true;
                }
            }

            // pega estados
            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri(base_url_pais_estado);

                var response = await client.GetAsync("api/State");

                if(response.IsSuccessStatusCode) {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    EditAmigo.Estados = JsonConvert.DeserializeObject<List<EstadoViewModel>>(responseContent);

                    pegouEstados = true;
                }
            }

            // pega user
            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri(base_url_amigo);

                var response = await client.GetAsync($"api/Friend?id_user={id}");

                if(response.IsSuccessStatusCode) {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    EditAmigo.Amigo = JsonConvert.DeserializeObject<FriendViewModel>(responseContent);

                    pegouUser = true;
                }
            }

            if(pegouPaises && pegouEstados && pegouUser)
                return View(EditAmigo);
            else
                return View("Error");

        }

        [HttpPost]
        public async Task<ActionResult> Edit(FormCollection collection, string id) {
            var data = new Dictionary<string, string>
            {
                {"Name", collection["Amigo.Name"]},
                {"LastName", collection["Amigo.LastName"]},
                {"Email", collection["Amigo.Email"]},
                {"Telephone", collection["Amigo.Telephone"]},
                {"BirthDate", collection["Amigo.BirthDate"]},
                {"IdCountry", collection["paises"]},
                {"IdState", collection["estados"]},
            };

            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri(base_url_amigo);

                using(var requestContent = new FormUrlEncodedContent(data)) {
                    var response = await client.PutAsync($"api/Friend?id_user={id}", requestContent);

                    if(response.IsSuccessStatusCode) {
                        return RedirectToAction("Index");
                    } else {
                        return View("Error");
                    }
                }
            }
        }

        [HttpGet]
        public async Task<ActionResult> Delete(string id) {
            FriendViewModel amigo = new FriendViewModel();

            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri(base_url_amigo);

                var response = await client.GetAsync($"api/Friend?id_user={id}");

                if(response.IsSuccessStatusCode) {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    amigo = JsonConvert.DeserializeObject<FriendViewModel>(responseContent);

                    return View(amigo);
                }
            }

            return View("Error");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id, FormCollection form) {
            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri(base_url_amigo);

                var response = await client.DeleteAsync($"api/Friend?id_user={id}");

                if(response.IsSuccessStatusCode) {
                    return RedirectToAction("Index");
                } else {
                    return View("Error");
                }
            }
        }

        [HttpGet]
        public async Task<ActionResult> Details(string id) {
            FriendViewModel amigo = new FriendViewModel();

            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri(base_url_amigo);

                var response = await client.GetAsync($"api/Friend?id_user={id}");

                if(response.IsSuccessStatusCode) {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    amigo = JsonConvert.DeserializeObject<FriendViewModel>(responseContent);

                    return View(amigo);
                }
            }

            return View("Error");
        }
    }
}