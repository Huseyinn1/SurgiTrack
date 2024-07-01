using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SurgiTrackUI.Models;
using System.Text;

namespace SurgiTrackUI.Controllers
{
    public class DiyafragmaHernisiController : Controller
    {
        public IActionResult DiyafragmaHernisi()
        {
            var viewModel = new AmeliyatListViewModel
            {

                Ameliyatlar = GetAmeliyats()

            };
            return View();
        }
        public IActionResult DiyafragmaHernisiAdd()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DiyafragmaHernisiAdd(DiyafragmaHernisi DiyafragmaHernisi)
        {

            using var httpClient = new HttpClient();

            var jsonContent = new StringContent(
                JsonConvert.SerializeObject(DiyafragmaHernisi),
                Encoding.UTF8,
                "application/json"
            );
            await httpClient.PostAsync("https://localhost:7207/api/DiyafragmaHernisi/DiyafragmaHernisiAdd", jsonContent);

            return View();
        }
        private List<Ameliyat> GetAmeliyats()
        {
            using var httpClient = new HttpClient();

            var apiUrl = "https://localhost:7207/api/Ameliyat/GetAllAmeliyat";
            var response = httpClient.GetStringAsync(apiUrl).Result;
            var ameliyats = JsonConvert.DeserializeObject<List<Ameliyat>>(response);

            return ameliyats;
        }
        public async Task<IActionResult> DiyafragmaHernisiListesi()
        {
            using var httpClient = new HttpClient();


            var search = HttpContext.Request.Query["search"].ToString();


            var apiUrl = "https://localhost:7207/api/DiyafragmaHernisi/GetAllDiyafragmaHernisi";

            var response = await httpClient.GetStringAsync(apiUrl);


            var DiyafragmaHernisiListesi = JsonConvert.DeserializeObject<List<DiyafragmaHernisi>>(response);



            return View(DiyafragmaHernisiListesi);
        }
        public async Task<IActionResult> TekilDiyafragmaHernisi(int id)
        {
            using var httpClient = new HttpClient();

            var response = await httpClient.GetStringAsync($"https://localhost:7207/api/DiyafragmaHernisi/GetByIdDiyafragmaHernisi?id={id}");

            var DiyafragmaHernisi = JsonConvert.DeserializeObject<DiyafragmaHernisi>(response);

            return View(DiyafragmaHernisi);
        }


        public async Task<IActionResult> Delete(int id)
        {
            using var httpClient = new HttpClient();


            var response = await httpClient.DeleteAsync($"https://localhost:7207/api/DiyafragmaHernisi/DiyafragmaHernisiDeleteById?id={id}");


            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction("DiyafragmaHernisiListesi");
            }
            else
            {

                var errorMessage = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, errorMessage);
                return RedirectToAction("DiyafragmaHernisiListesi");
            }


        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            using var httpClient = new HttpClient();

            var response = await httpClient.GetStringAsync($"https://localhost:7207/api/DiyafragmaHernisi/GetByIdDiyafragmaHernisi?id={id}");

            var DiyafragmaHernisi = JsonConvert.DeserializeObject<DiyafragmaHernisi>(response);

            return View("Edit", DiyafragmaHernisi);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(DiyafragmaHernisi DiyafragmaHernisi)
        {
            using var httpClient = new HttpClient();

            var jsonContent = new StringContent(
                JsonConvert.SerializeObject(DiyafragmaHernisi),
                Encoding.UTF8,
                "application/json"
            );

            await httpClient.PutAsync($"https://localhost:7207/api/DiyafragmaHernisi/DiyafragmaHernisiUpdate", jsonContent);
            return RedirectToAction("DiyafragmaHernisiListesi");
        }
    }
}