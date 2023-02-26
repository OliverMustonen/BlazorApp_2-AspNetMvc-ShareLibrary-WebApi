using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SharedLibrary.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace AspNetMvc.Controllers
{
    public class ProductsController : Controller
    {
        // GET: ProductsController
        public async Task<ActionResult> Index()
        {
            var http = new HttpClient();
            var response = await http.GetAsync("https://localhost:44369/api/Products");
            var products = JsonConvert.DeserializeObject<List<Product>>(await response.Content.ReadAsStringAsync());

            return View(products);
        }

        // GET: ProductsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var http = new HttpClient();
            var product = await http.GetFromJsonAsync<Product>($"https://localhost:44369/api/Products/{id}");
            //var product = JsonConvert.DeserializeObject<Product>(await response.Content.ReadAsStringAsync());

            return View(product);
        }



        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Product product)
        {
            try
            {
                var client = new HttpClient();
                await client.PostAsJsonAsync("https://localhost:44369/api/Products", product);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
