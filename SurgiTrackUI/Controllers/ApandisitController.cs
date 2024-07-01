using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SurgiTrackUI.Models;
using System.Text;

namespace SurgiTrackUI.Controllers
{
    public class ApandisitController : Controller
    {
        public IActionResult Apandisit()
        {
            return View();
        }
        public IActionResult ApandisitAdd()
        {
            var viewModel = new AmeliyatListViewModel
            {

                Ameliyatlar = GetAmeliyats()

            };
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ApandisitAdd(Apandisit Apandisit)
        {

            using var httpClient = new HttpClient();

            var jsonContent = new StringContent(
                JsonConvert.SerializeObject(Apandisit),
                Encoding.UTF8,
                "application/json"
            );
            await httpClient.PostAsync("https://localhost:7207/api/Apandisit/ApandisitAdd", jsonContent);

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
        public async Task<IActionResult> ApandisitListesi()
        {
            using var httpClient = new HttpClient();


            var search = HttpContext.Request.Query["search"].ToString();


            var apiUrl = "https://localhost:7207/api/Apandisit/GetAllApandisit";

            var response = await httpClient.GetStringAsync(apiUrl);


            var ApandisitListesi = JsonConvert.DeserializeObject<List<Apandisit>>(response);



            return View(ApandisitListesi);
        }
        public async Task<IActionResult> TekilApandisit(int id)
        {
            using var httpClient = new HttpClient();

            var response = await httpClient.GetStringAsync($"https://localhost:7207/api/Apandisit/GetByIdApandisit?id={id}");

            var Apandisit = JsonConvert.DeserializeObject<Apandisit>(response);

            return View(Apandisit);
        }


        public async Task<IActionResult> Delete(int id)
        {
            using var httpClient = new HttpClient();


            var response = await httpClient.DeleteAsync($"https://localhost:7207/api/Apandisit/ApandisitDeleteById?id={id}");


            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction("ApandisitListesi");
            }
            else
            {

                var errorMessage = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, errorMessage);
                return RedirectToAction("ApandisitListesi");
            }


        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            using var httpClient = new HttpClient();

            var response = await httpClient.GetStringAsync($"https://localhost:7207/api/Apandisit/GetByIdApandisit?id={id}");

            var Apandisit = JsonConvert.DeserializeObject<Apandisit>(response);

            return View("Edit", Apandisit);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Apandisit Apandisit)
        {
            using var httpClient = new HttpClient();

            var jsonContent = new StringContent(
                JsonConvert.SerializeObject(Apandisit),
                Encoding.UTF8,
                "application/json"
            );

            await httpClient.PutAsync($"https://localhost:7207/api/Apandisit/ApandisitUpdate", jsonContent);
            return RedirectToAction("ApandisitListesi");
        }
    }
}