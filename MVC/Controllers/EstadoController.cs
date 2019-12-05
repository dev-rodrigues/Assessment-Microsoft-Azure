using MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class EstadoController : Controller
    {
        private string base_url = "http://localhost:58373";

        // GET: Country
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var estados = new List<EstadoViewModel>();
            var rj = new EstadoViewModel();
            var sp = new EstadoViewModel();
            rj.Id = "1";
            rj.Nome = "Rio de Janeiro";
            rj.FotoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/73/Bandeira_do_estado_do_Rio_de_Janeiro.svg/1200px-Bandeira_do_estado_do_Rio_de_Janeiro.svg.png";

            sp.Id = "2";
            sp.Nome = "Sao Paulo";
            sp.FotoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2b/Bandeira_do_estado_de_S%C3%A3o_Paulo.svg/275px-Bandeira_do_estado_de_S%C3%A3o_Paulo.svg.png";
            estados.Add(rj);
            estados.Add(sp);

            //var estados = new List<EstadoViewModel>();

            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(base_url);

            //    var response = await client.GetAsync($"/api/paises");

            //    if (response.IsSuccessStatusCode)
            //    {
            //        var responseContent = await response.Content.ReadAsStringAsync();

            //        estados = JsonConvert.DeserializeObject<List<EstadoViewModel>>(responseContent);

            //        return View(estados);
            //    }
            //}

            return View(estados);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(FormCollection collection)
        {
            var novoPais = new EstadoViewModel();

            var data = new Dictionary<string, string>
            {
                {"Nome", collection["Nome"]},
                {"FotoUrl", collection["FotoUrl"]}
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(base_url);

                using (var requestContent = new FormUrlEncodedContent(data))
                {
                    var response = await client.PostAsync("api/create/pais", requestContent);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Edit(string id)
        {
            EstadoViewModel estado = new EstadoViewModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(base_url);

                var response = await client.GetAsync($"api/Country/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    estado = JsonConvert.DeserializeObject<EstadoViewModel>(responseContent);

                    return View(estado);
                }
            }

            return View();
        }

        [HttpPut]
        public async Task<ActionResult> Edit(FormCollection collection, string id)
        {
            var data = new Dictionary<string, string>
            {
                {"Nome", collection["Nome"]},
                {"FotoUrl", collection["FotoUrl"]}
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(base_url);

                using (var requestContent = new FormUrlEncodedContent(data))
                {
                    var response = await client.PutAsync("Api/Account/update", requestContent);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View();
                    }
                }
            }
        }


        [HttpGet]
        public async Task<ActionResult> Delete(string id)
        {
            EstadoViewModel estado = new EstadoViewModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(base_url);

                var response = await client.GetAsync($"api/Country/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    estado = JsonConvert.DeserializeObject<EstadoViewModel>(responseContent);

                    return View(estado);
                }
            }

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id, FormCollection collection)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(base_url);

                var response = await client.GetAsync($"Api/delete{id}");

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
        }

        [HttpGet]
        public async Task<ActionResult> Details(string id)
        {
            EstadoViewModel estado = new EstadoViewModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(base_url);

                var response = await client.GetAsync($"api/Country/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    estado = JsonConvert.DeserializeObject<EstadoViewModel>(responseContent);

                    return View(estado);
                }
            }

            return View();
        }
    }
}