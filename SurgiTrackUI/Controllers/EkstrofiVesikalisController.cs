using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SurgiTrackUI.Models;
using System.Text;

namespace SurgiTrackUI.Controllers
{
    public class EkstrofiVesikalisController : Controller
    {
        public IActionResult EkstrofiVesikalis()
        {
            return View();
        }
        public IActionResult EkstrofiVesikalisAdd()
        {
            var viewModel = new AmeliyatListViewModel
            {

                Ameliyatlar = GetAmeliyats()

            };
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EkstrofiVesikalisAdd(EkstrofiVesikalis EkstrofiVesikalis)
        {

            using var httpClient = new HttpClient();

            var jsonContent = new StringContent(
                JsonConvert.SerializeObject(EkstrofiVesikalis),
                Encoding.UTF8,
                "application/json"
            );
            await httpClient.PostAsync("https://localhost:7207/api/EkstrofiVesikalis/EkstrofiVesikalisAdd", jsonContent);

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
        public async Task<IActionResult> EkstrofiVesikalisListesi()
        {
            using var httpClient = new HttpClient();


            var search = HttpContext.Request.Query["search"].ToString();


            var apiUrl = "https://localhost:7207/api/EkstrofiVesikalis/GetAllEkstrofiVesikalis";

            var response = await httpClient.GetStringAsync(apiUrl);


            var EkstrofiVesikalisListesi = JsonConvert.DeserializeObject<List<EkstrofiVesikalis>>(response);



            return View(EkstrofiVesikalisListesi);
        }
        public async Task<IActionResult> TekilEkstrofiVesikalis(int id)
        {
            using var httpClient = new HttpClient();

            var response = await httpClient.GetStringAsync($"https://localhost:7207/api/EkstrofiVesikalis/GetByIdEkstrofiVesikalis?id={id}");

            var EkstrofiVesikalis = JsonConvert.DeserializeObject<EkstrofiVesikalis>(response);

            return View(EkstrofiVesikalis);
        }


        public async Task<IActionResult> Delete(int id)
        {
            using var httpClient = new HttpClient();


            var response = await httpClient.DeleteAsync($"https://localhost:7207/api/EkstrofiVesikalis/EkstrofiVesikalisDeleteById?id={id}");


            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction("EkstrofiVesikalisListesi");
            }
            else
            {

                var errorMessage = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, errorMessage);
                return RedirectToAction("EkstrofiVesikalisListesi");
            }


        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            using var httpClient = new HttpClient();

            var response = await httpClient.GetStringAsync($"https://localhost:7207/api/EkstrofiVesikalis/GetByIdEkstrofiVesikalis?id={id}");

            var EkstrofiVesikalis = JsonConvert.DeserializeObject<EkstrofiVesikalis>(response);

            return View("Edit", EkstrofiVesikalis);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(EkstrofiVesikalis EkstrofiVesikalis)
        {
            using var httpClient = new HttpClient();

            var jsonContent = new StringContent(
                JsonConvert.SerializeObject(EkstrofiVesikalis),
                Encoding.UTF8,
                "application/json"
            );

            await httpClient.PutAsync($"https://localhost:7207/api/EkstrofiVesikalis/EkstrofiVesikalisUpdate", jsonContent);
            return RedirectToAction("EkstrofiVesikalisListesi");
        }
    }
}