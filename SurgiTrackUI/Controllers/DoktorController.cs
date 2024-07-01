using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SurgiTrackUI.Models;
using System.Text;

namespace SurgiTrackUI.Controllers
{
    public class DoktorController : Controller
    {
        public IActionResult Doktor()
        {
            return View();
        }
        public IActionResult DoktorAdd()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DoktorAdd(Doktor doktor)
        {

            using var httpClient = new HttpClient();

            var jsonContent = new StringContent(
                JsonConvert.SerializeObject(doktor),
                Encoding.UTF8,
                "application/json"
            );
            await httpClient.PostAsync("https://localhost:7207/api/Doktor/DoktorAdd", jsonContent);




            return View();
        }
        public async Task<IActionResult> DoktorListesi()
        {
            using var httpClient = new HttpClient();


            var search = HttpContext.Request.Query["search"].ToString();


            var apiUrl = "https://localhost:7207/api/Doktor/GetAllDoktor";

            var response = await httpClient.GetStringAsync(apiUrl);


            var DoktorListesi = JsonConvert.DeserializeObject<List<Doktor>>(response);



            return View(DoktorListesi);
        }
   
        public async Task<IActionResult> TekilDoktor(DoktorAmeliyatViewModel viewModel,int id)
        {
            using var httpClient = new HttpClient();

            var response = await httpClient.GetStringAsync($"https://localhost:7207/api/Doktor/GetByIdDoktor?id={id}");

            var doktor = JsonConvert.DeserializeObject<Doktor>(response);
            var ameliyats = GetAmeliyats(id);

            // Hasta modeline Ameliyatlar'ı ekleyin
            viewModel.Doktor = doktor;
            viewModel.Ameliyatlar = ameliyats;

            return View(viewModel);
        }
        private List<Ameliyat> GetAmeliyats(int doktorid)
        {
            using var httpClient = new HttpClient();

            var apiUrl = "https://localhost:7207/api/Ameliyat/GetAllAmeliyat";

            // API'ye isteği gönder ve sonucunu bekler
            var response = httpClient.GetStringAsync(apiUrl).Result;

            // API'den gelen cevabı JSON'dan nesneye dönüştür
            var allAmeliyats = JsonConvert.DeserializeObject<List<Ameliyat>>(response);

            // Belirli bir hasta ID'sine ait ameliyatları filtrele
            var ameliyats = allAmeliyats.Where(a => a.DoktorId == doktorid).ToList();

            return ameliyats;
        }


        public async Task<IActionResult> Delete(int id)
        {
            using var httpClient = new HttpClient();


            var response = await httpClient.DeleteAsync($"https://localhost:7207/api/Doktor/DoktorDeleteById?id={id}");


            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction("DoktorListesi");
            }
            else
            {

                var errorMessage = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, errorMessage);
                return RedirectToAction("DoktorListesi");
            }


        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            using var httpClient = new HttpClient();

            var response = await httpClient.GetStringAsync($"https://localhost:7207/api/Doktor/GetByIdDoktor?id={id}");

            var Doktor = JsonConvert.DeserializeObject<Doktor>(response);

            return View("Edit", Doktor);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Doktor Doktor)
        {
            using var httpClient = new HttpClient();

            var jsonContent = new StringContent(
                JsonConvert.SerializeObject(Doktor),
                Encoding.UTF8,
                "application/json"
            );

            await httpClient.PutAsync($"https://localhost:7207/api/Doktor/DoktorUpdate", jsonContent);
            return RedirectToAction("DoktorListesi");
        }
    }
}