using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SurgiTrackUI.Models;
using System.Text;

namespace SurgiTrackUI.Controllers
{
    public class HastaController : Controller
    {
        public IActionResult Hasta()
        {
            return View();
        }
        public IActionResult HastaAdd()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> HastaAdd(Hasta hasta)
        {

            using var httpClient = new HttpClient();

            var jsonContent = new StringContent(
                JsonConvert.SerializeObject(hasta),
                Encoding.UTF8,
                "application/json"
            );
            await httpClient.PostAsync("https://localhost:7207/api/Hasta/HastaAdd", jsonContent);




            return View();
        }
        public async Task<IActionResult> HastaListesi()
        {
            using var httpClient = new HttpClient();

       
            var search = HttpContext.Request.Query["search"].ToString();

    
            var apiUrl = "https://localhost:7207/api/Hasta/GetAllHasta";

            var response = await httpClient.GetStringAsync(apiUrl);

          
            var hastaListesi = JsonConvert.DeserializeObject<List<Hasta>>(response);

    
            if (!string.IsNullOrEmpty(search))
            {
                var searchKeywords = search.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                     .Select(keyword => keyword.ToLower())
                                     .ToList();

                hastaListesi = hastaListesi
                    .Where(hasta => searchKeywords.All(keyword =>
                                    hasta.Ad.ToLower().Contains(keyword) ||
                                    hasta.Soyad.ToLower().Contains(keyword)))
                    .ToList();
            }

            return View(hastaListesi);
        }
        public async Task<IActionResult> TekilHasta(HastaAmeliyatViewModel viewModel ,int id)
        {
            using var httpClient = new HttpClient();

            var response = await httpClient.GetStringAsync($"https://localhost:7207/api/Hasta/GetByIdHasta?id={id}");

            var hasta = JsonConvert.DeserializeObject<Hasta>(response);

            // Ameliyatları yüklemek için ayrı bir metodu çağırın
            var ameliyats = GetAmeliyats(id);

            // Hasta modeline Ameliyatlar'ı ekleyin
            viewModel.Hasta = hasta;
            viewModel.Ameliyatlar = ameliyats;

            return View(viewModel);
        }
        private List<Ameliyat> GetAmeliyats(int hastaId)
        {
            using var httpClient = new HttpClient();

            var apiUrl = "https://localhost:7207/api/Ameliyat/GetAllAmeliyat";

            // API'ye isteği gönder ve sonucunu bekler
            var response =  httpClient.GetStringAsync(apiUrl).Result;

            // API'den gelen cevabı JSON'dan nesneye dönüştür
            var allAmeliyats = JsonConvert.DeserializeObject<List<Ameliyat>>(response);

            // Belirli bir hasta ID'sine ait ameliyatları filtrele
            var ameliyats = allAmeliyats.Where(a => a.HastaId == hastaId).ToList();

            return ameliyats;
        }

        public async Task<IActionResult> Delete(int id)
         {
             using var httpClient = new HttpClient();


             var response = await httpClient.DeleteAsync($"https://localhost:7207/api/Hasta/HastaDeleteById?id={id}");


             if (response.IsSuccessStatusCode)
             {

                 return RedirectToAction("HastaListesi");
             }
             else
             {

                 var errorMessage = await response.Content.ReadAsStringAsync();
                 ModelState.AddModelError(string.Empty, errorMessage);
                 return RedirectToAction("HastaListesi");
             }


         }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            using var httpClient = new HttpClient();

            var response = await httpClient.GetStringAsync($"https://localhost:7207/api/Hasta/GetByIdHasta?id={id}");

            var hasta = JsonConvert.DeserializeObject<Hasta>(response);

            return View("Edit",hasta);
        }

     
        [HttpPost]
        public async Task<IActionResult> Edit(Hasta hasta)
        {
            using var httpClient = new HttpClient();
           
            var jsonContent = new StringContent(
                JsonConvert.SerializeObject(hasta),
                Encoding.UTF8,
                "application/json"
            );

            await httpClient.PutAsync($"https://localhost:7207/api/Hasta/HastaUpdate", jsonContent);
            return RedirectToAction("HastaListesi");
        }
    }
}