using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SurgiTrackUI.Models;
using System.Text;

namespace SurgiTrackUI.Controllers
{
    public class KolonPullThroughKadinController : Controller
    {
        public IActionResult KolonPullThroughKadin()
        {
            return View();
        }
        public IActionResult KolonPullThroughKadinAdd()
        {
            var viewModel = new AmeliyatListViewModel
            {

                Ameliyatlar = GetAmeliyats()

            };
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> KolonPullThroughKadinAdd(KolonPullThroughKadin KolonPullThroughKadin)
        {

            using var httpClient = new HttpClient();

            var jsonContent = new StringContent(
                JsonConvert.SerializeObject(KolonPullThroughKadin),
                Encoding.UTF8,
                "application/json"
            );
            await httpClient.PostAsync("https://localhost:7207/api/KolonPullThroughKadin/KolonPullThroughKadinAdd", jsonContent);

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
        public async Task<IActionResult> KolonPullThroughKadinListesi()
        {
            using var httpClient = new HttpClient();


            var search = HttpContext.Request.Query["search"].ToString();


            var apiUrl = "https://localhost:7207/api/KolonPullThroughKadin/GetAllKolonPullThroughKadin";

            var response = await httpClient.GetStringAsync(apiUrl);


            var KolonPullThroughKadinListesi = JsonConvert.DeserializeObject<List<KolonPullThroughKadin>>(response);



            return View(KolonPullThroughKadinListesi);
        }
        public async Task<IActionResult> TekilKolonPullThroughKadin(int id)
        {
            using var httpClient = new HttpClient();

            var response = await httpClient.GetStringAsync($"https://localhost:7207/api/KolonPullThroughKadin/GetByIdKolonPullThroughKadin?id={id}");

            var KolonPullThroughKadin = JsonConvert.DeserializeObject<KolonPullThroughKadin>(response);

            return View(KolonPullThroughKadin);
        }


        public async Task<IActionResult> Delete(int id)
        {
            using var httpClient = new HttpClient();


            var response = await httpClient.DeleteAsync($"https://localhost:7207/api/KolonPullThroughKadin/KolonPullThroughKadinDeleteById?id={id}");


            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction("KolonPullThroughKadinListesi");
            }
            else
            {

                var errorMessage = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, errorMessage);
                return RedirectToAction("KolonPullThroughKadinListesi");
            }


        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            using var httpClient = new HttpClient();

            var response = await httpClient.GetStringAsync($"https://localhost:7207/api/KolonPullThroughKadin/GetByIdKolonPullThroughKadin?id={id}");

            var KolonPullThroughKadin = JsonConvert.DeserializeObject<KolonPullThroughKadin>(response);

            return View("Edit", KolonPullThroughKadin);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(KolonPullThroughKadin KolonPullThroughKadin)
        {
            using var httpClient = new HttpClient();

            var jsonContent = new StringContent(
                JsonConvert.SerializeObject(KolonPullThroughKadin),
                Encoding.UTF8,
                "application/json"
            );

            await httpClient.PutAsync($"https://localhost:7207/api/KolonPullThroughKadin/KolonPullThroughKadinUpdate", jsonContent);
            return RedirectToAction("KolonPullThroughKadinListesi");
        }
    }
}