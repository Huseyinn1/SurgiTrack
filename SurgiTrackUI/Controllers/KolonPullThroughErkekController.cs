using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SurgiTrackUI.Models;
using System.Text;

namespace SurgiTrackUI.Controllers
{
    public class KolonPullThroughErkekController : Controller
    {
        public IActionResult KolonPullThroughErkek()
        {
            return View();
        }
        public IActionResult KolonPullThroughErkekAdd()
        {
            var viewModel = new AmeliyatListViewModel
            {

                Ameliyatlar = GetAmeliyats()

            };
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> KolonPullThroughErkekAdd(KolonPullThroughErkek KolonPullThroughErkek)
        {

            using var httpClient = new HttpClient();

            var jsonContent = new StringContent(
                JsonConvert.SerializeObject(KolonPullThroughErkek),
                Encoding.UTF8,
                "application/json"
            );
            await httpClient.PostAsync("https://localhost:7207/api/KolonPullThroughErkek/KolonPullThroughErkekAdd", jsonContent);

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
        public async Task<IActionResult> KolonPullThroughErkekListesi()
        {
            using var httpClient = new HttpClient();


            var search = HttpContext.Request.Query["search"].ToString();


            var apiUrl = "https://localhost:7207/api/KolonPullThroughErkek/GetAllKolonPullThroughErkek";

            var response = await httpClient.GetStringAsync(apiUrl);


            var KolonPullThroughErkekListesi = JsonConvert.DeserializeObject<List<KolonPullThroughErkek>>(response);



            return View(KolonPullThroughErkekListesi);
        }
        public async Task<IActionResult> TekilKolonPullThroughErkek(int id)
        {
            using var httpClient = new HttpClient();

            var response = await httpClient.GetStringAsync($"https://localhost:7207/api/KolonPullThroughErkek/GetByIdKolonPullThroughErkek?id={id}");

            var KolonPullThroughErkek = JsonConvert.DeserializeObject<KolonPullThroughErkek>(response);

            return View(KolonPullThroughErkek);
        }


        public async Task<IActionResult> Delete(int id)
        {
            using var httpClient = new HttpClient();


            var response = await httpClient.DeleteAsync($"https://localhost:7207/api/KolonPullThroughErkek/KolonPullThroughErkekDeleteById?id={id}");


            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction("KolonPullThroughErkekListesi");
            }
            else
            {

                var errorMessage = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, errorMessage);
                return RedirectToAction("KolonPullThroughErkekListesi");
            }


        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            using var httpClient = new HttpClient();

            var response = await httpClient.GetStringAsync($"https://localhost:7207/api/KolonPullThroughErkek/GetByIdKolonPullThroughErkek?id={id}");

            var KolonPullThroughErkek = JsonConvert.DeserializeObject<KolonPullThroughErkek>(response);

            return View("Edit", KolonPullThroughErkek);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(KolonPullThroughErkek KolonPullThroughErkek)
        {
            using var httpClient = new HttpClient();

            var jsonContent = new StringContent(
                JsonConvert.SerializeObject(KolonPullThroughErkek),
                Encoding.UTF8,
                "application/json"
            );

            await httpClient.PutAsync($"https://localhost:7207/api/KolonPullThroughErkek/KolonPullThroughErkekUpdate", jsonContent);
            return RedirectToAction("KolonPullThroughErkekListesi");
        }
    }
}