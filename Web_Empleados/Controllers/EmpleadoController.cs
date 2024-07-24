using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Json;
using Web_Empleados.Helpers;
using Web_Empleados.Models;

namespace Web_Empleados.Controllers
{
    public class EmpleadoController : Controller
    {
        InformationExtends _api = new InformationExtends();
        // GET: EmpleadoController
        public async Task<IActionResult> Index()
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage response = await client.GetAsync("api/Empleados");
            response.EnsureSuccessStatusCode();
            List<Empleado> responseBody = JsonConvert.DeserializeObject<List<Empleado>>(response.Content.ReadAsStringAsync().Result.ToString()); ;
            return View(responseBody);
        }

        // GET: EmpleadoController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage response = await client.GetAsync(string.Concat("api/Empleados/", id));
            response.EnsureSuccessStatusCode();
            var responseBody = JsonConvert.DeserializeObject<Empleado>(response.Content.ReadAsStringAsync().Result.ToString());
            return View(responseBody);
        }

        // GET: EmpleadoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpleadoController/Create
        [HttpPost]
        public ActionResult Create(Empleado empleado)
        {
            try
            {
                HttpClient client = _api.Initial();
                var response = client.PostAsJsonAsync<Empleado>("api/Empleados", empleado);

                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpleadoController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage response = await client.GetAsync(string.Concat("api/Empleados/", id));
            var responseBody = JsonConvert.DeserializeObject<Empleado>(response.Content.ReadAsStringAsync().Result.ToString());
            return View(responseBody);
        }

        // POST: EmpleadoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Empleado empleado)
        {
            try
            {
                HttpClient client = _api.Initial();
                var response = client.PutAsJsonAsync<Empleado>("api/Empleados", empleado);

                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpleadoController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage response = await client.GetAsync(string.Concat("api/Empleados/", id));
            var responseBody = JsonConvert.DeserializeObject<Empleado>(response.Content.ReadAsStringAsync().Result.ToString());
            return View(responseBody);
        }

        // POST: EmpleadoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                HttpClient client = _api.Initial();
                var response = await client.DeleteAsync(string.Concat("api/Empleados", id));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
