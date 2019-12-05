using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Controllers
{
    public class PaisesController : Controller
    {
        // GET: Paises
        public ActionResult Index()
        {
            PaisesViewModel paises = new PaisesViewModel();

            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(BaseUrl.URL);

                var response = await cliente.GetAsync($"/api/paises");

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    paises = JsonConvert.DeserializeObjectList<<ProfileViewModel>>(responseContent);

                    return View(paises);
                }
            }

            return View();
        }

        // GET: Paises/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Paises/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paises/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Paises/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Paises/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Paises/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Paises/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
