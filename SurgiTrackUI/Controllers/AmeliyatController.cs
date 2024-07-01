using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SurgiTrackUI.Models;
using System.Text;

namespace SurgiTrackUI.Controllers
{
    public class AmeliyatController : Controller
    {
        public IActionResult Ameliyat()
        {
            return View();
        }
        public IActionResult AmeliyatAdd()
        {
            var viewModel = new AmeliyatViewModel
            {
              
                Doktorlar = GetDoktorListesi(),
                Hastalar = GetHastaListesi()
            };

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AmeliyatAdd(AmeliyatViewModel ameliyatViewModel)
        {
        
            using var httpClient = new HttpClient();

            var jsonContent = new StringContent(
                JsonConvert.SerializeObject(ameliyatViewModel.Ameliyat),
                Encoding.UTF8,
                "application/json"
            );
            await httpClient.PostAsync("https://localhost:7207/api/Ameliyat/AmeliyatAdd", jsonContent);




            return View("AmeliyatAdd", ameliyatViewModel);
        }
        private List<Doktor> GetDoktorListesi()
        {
            using var httpClient = new HttpClient();

            var apiUrl = "https://localhost:7207/api/Doktor/GetAllDoktor";
            var response = httpClient.GetStringAsync(apiUrl).Result;
            var doktorListesi = JsonConvert.DeserializeObject<List<Doktor>>(response);

            return doktorListesi;
        }
   

        // Hasta listesini getiren bir metod
        private List<Hasta> GetHastaListesi()
        {
            using var httpClient = new HttpClient();

            var apiUrl = "https://localhost:7207/api/Hasta/GetAllHasta";
            var response = httpClient.GetStringAsync(apiUrl).Result;
            var hastaListesi = JsonConvert.DeserializeObject<List<Hasta>>(response);

            return hastaListesi;
        }
        public async Task<IActionResult> AmeliyatListesi()
        {
            using var httpClient = new HttpClient();


            var apiUrl = "https://localhost:7207/api/Ameliyat/GetAllAmeliyat";

            var response = await httpClient.GetStringAsync(apiUrl);


            var ameliyatListesi = JsonConvert.DeserializeObject<List<Ameliyat>>(response);
            var viewModel = new AmeliyatListViewModel
            {
                Ameliyatlar = ameliyatListesi,
                Doktorlar = GetDoktorListesi(),
                Hastalar = GetHastaListesi()
            };

            return View(viewModel);

        }
        public async Task<IActionResult> TekilAmeliyat(AmeliyatDoktorHastaViewModel viewModel,int id)
        {
            using var httpClient = new HttpClient();

            var response = await httpClient.GetStringAsync($"https://localhost:7207/api/Ameliyat/GetByIdAmeliyat?id={id}");

            var ameliyat = JsonConvert.DeserializeObject<Ameliyat>(response);
            
           
            // Ameliyat modeline doktor listesini ekle
            var doktor = GetDoktor(ameliyat.DoktorId);
            var hasta = GetHasta(ameliyat.HastaId);
            viewModel.doktor = doktor;
            viewModel.hasta = hasta;
            viewModel.Ameliyatlar = ameliyat;

            return View(viewModel);
        }
        private List<Doktor> GetDoktor(int id)
        {
            using var httpClient = new HttpClient();

            var apiUrl = "https://localhost:7207/api/Doktor/GetAllDoktor";
            var response = httpClient.GetStringAsync(apiUrl).Result;

            // JSON formatı değiştiyse, aşağıdaki gibi deserializasyonu güncelleyin
            var doktor = JsonConvert.DeserializeObject<List<Doktor>>(response);
            var doktors = doktor.Where(a => a.Id == id).ToList();

            return doktors;

        }
        private List<Hasta> GetHasta(int id)
        {
            using var httpClient = new HttpClient();

            var apiUrl = "https://localhost:7207/api/Hasta/GetAllHasta";
            var response = httpClient.GetStringAsync(apiUrl).Result;

            // JSON formatı değiştiyse, aşağıdaki gibi deserializasyonu güncelleyin
            var hasta = JsonConvert.DeserializeObject<List<Hasta>>(response);
            var hastas = hasta.Where(a => a.Id == id).ToList();

            return hastas;

        }

        public async Task<IActionResult> Delete(int id)
        {
            using var httpClient = new HttpClient();


            var response = await httpClient.DeleteAsync($"https://localhost:7207/api/Ameliyat/AmeliyatDeleteById?id={id}");


            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction("AmeliyatListesi");
            }
            else
            {

                var errorMessage = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, errorMessage);
                return RedirectToAction("AmeliyatListesi");
            }


        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            using var httpClient = new HttpClient();

            var response = await httpClient.GetStringAsync($"https://localhost:7207/api/Ameliyat/GetByIdAmeliyat?id={id}");

            var ameliyat = JsonConvert.DeserializeObject<Ameliyat>(response);

         
            /*var hastalar = new List<Hasta>();
            
            var doktor = ApiService.GetDoktor(ameliyat.DoktorId);
             var hasta = ApiService.GetHasta(ameliyat.HastaId);
           

            viewModel.Ameliyatlarr = ameliyat;
            viewModel.Doktorlar = doktor;
            viewModel.Hastalar = hasta;*/
            return View("Edit", ameliyat);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Ameliyat ameliyat)
        {
            using var httpClient = new HttpClient();

            var jsonContent = new StringContent(
                JsonConvert.SerializeObject(ameliyat),
                Encoding.UTF8,
                "application/json"
            );

            await httpClient.PutAsync($"https://localhost:7207/api/Ameliyat/AmeliyatUpdate", jsonContent);
            return RedirectToAction("AmeliyatListesi");
        }
        }
}
