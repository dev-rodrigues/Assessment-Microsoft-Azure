﻿using MVC.Models;
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
    public class CountryController : Controller {
        private readonly string base_url = "http://localhost:54595";

        // GET: Country
        [HttpGet]
        public async Task<ActionResult> Index() {
            var paises = new List<PaisViewModel>();

            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri(base_url);

                var response = await client.GetAsync("api/Country");

                if(response.IsSuccessStatusCode) {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    paises = JsonConvert.DeserializeObject<List<PaisViewModel>>(responseContent);

                    return View(paises);
                }
            }

            return View("Error");
        }

        [HttpGet]
        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(FormCollection collection, HttpPostedFileBase foto) {

            //TEM FOTO E TEM NOME DO PAIS
            if(foto != null && collection["name"].ToString() != null) {

                string code_img = Guid.NewGuid().ToString();
                new UploadAzure().UploadDeArquivo(foto.InputStream, $"{code_img}.png");


                var data = new Dictionary<string, string>
                {
                    {"Name", collection["Name"]},
                    {"IdImage", code_img}
                };

                using(var client = new HttpClient()) {
                    client.BaseAddress = new Uri(base_url);

                    using(var requestContent = new FormUrlEncodedContent(data)) {
                        var response = await client.PostAsync("api/Country", requestContent);

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
            PaisViewModel pais = new PaisViewModel();

            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri(base_url);

                var response = await client.GetAsync($"api/Country/{id}");

                if(response.IsSuccessStatusCode) {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    pais = JsonConvert.DeserializeObject<PaisViewModel>(responseContent);

                    return View(pais);
                }
            }

            return View("Error");

        }

        [HttpPost]
        public async Task<ActionResult> Edit(FormCollection collection, string id) {
            var data = new Dictionary<string, string>
            {
                {"Name", collection["Name"]},
                {"IdImage", collection["IdImage"]}
            };

            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri(base_url);

                using(var requestContent = new FormUrlEncodedContent(data)) {
                    var response = await client.PutAsync($"api/Country/{id}", requestContent);

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
            PaisViewModel pais = new PaisViewModel();

            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri(base_url);

                var response = await client.GetAsync($"api/Country/{id}");

                if(response.IsSuccessStatusCode) {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    pais = JsonConvert.DeserializeObject<PaisViewModel>(responseContent);

                    return View(pais);
                }
            }

            return View("Error");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id, FormCollection form) {
            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri(base_url);

                var response = await client.DeleteAsync($"api/Country/{id}");

                if(response.IsSuccessStatusCode) {
                    return RedirectToAction("Index");
                } else {
                    return View("Error");
                }
            }
        }

        [HttpGet]
        public async Task<ActionResult> Details(string id) {
            PaisViewModel pais = new PaisViewModel();

            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri(base_url);

                var response = await client.GetAsync($"api/Country/{id}");

                if(response.IsSuccessStatusCode) {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    pais = JsonConvert.DeserializeObject<PaisViewModel>(responseContent);

                    return View(pais);
                }
            }

            return View("Error");
        }

    }
}