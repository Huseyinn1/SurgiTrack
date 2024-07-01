using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SurgiTrackUI.Models;
using System.Text;

namespace SurgiTrackUI.Controllers
{
    public class AnalAtreziController : Controller
    {
       
        public IActionResult AnalAtrezi()
        {
            return View();
        }
        public IActionResult AnalAtreziAdd()
        {
            var viewModel = new AmeliyatListViewModel
            {

                Ameliyatlar = GetAmeliyats()
              
            };

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AnalAtreziAdd(AmeliyatListViewModel ameliyatViewModel)
        {

            using var httpClient = new HttpClient();

            var jsonContent = new StringContent(
                JsonConvert.SerializeObject(ameliyatViewModel.AnalAtreziss),
                Encoding.UTF8,
                "application/json"
            );
            await httpClient.PostAsync("https://localhost:7207/api/AnalAtrezi/AnalAtreziAdd", jsonContent);




            return View("AnalAtreziAdd", ameliyatViewModel);
        }
        private List<Ameliyat> GetAmeliyats()
        {
            using var httpClient = new HttpClient();

            var apiUrl = "https://localhost:7207/api/Ameliyat/GetAllAmeliyat";
            var response = httpClient.GetStringAsync(apiUrl).Result;
            var ameliyats = JsonConvert.DeserializeObject<List<Ameliyat>>(response);

            return ameliyats;
        }
      
    

        public async Task<IActionResult> AnalAtreziListesi()
        {
            using var httpClient = new HttpClient();


            var search = HttpContext.Request.Query["search"].ToString();


            var apiUrl = "https://localhost:7207/api/AnalAtrezi/GetAllAnalAtrezi";

            var response = await httpClient.GetStringAsync(apiUrl);


            var AnalAtreziListesi = JsonConvert.DeserializeObject<List<AnalAtrezi>>(response);

            var viewModel = new AmeliyatListViewModel
            {
                AnalAtrezis = AnalAtreziListesi,
                Ameliyatlar=  ApiService.GetAmeliyatListesi(),
                Hastalar= ApiService.GetHastaListesi(),
                Doktorlar= ApiService.GetDoktorListesi()
            };

            return View(viewModel);
        }
    

     
        public async Task<IActionResult> TekilAnalAtrezi(AmeliyatListViewModel viewModel, int id)
        {
            using var httpClient = new HttpClient();

            var response = await httpClient.GetStringAsync($"https://localhost:7207/api/AnalAtrezi/GetByIdAnalAtrezi?id={id}");

            var AnalAtrezi = JsonConvert.DeserializeObject<AnalAtrezi>(response);
            var doktorlar = new List<Doktor>();
            var hastalar = new List<Hasta>();
            var ameliyat = ApiService.GetAmeliyat(AnalAtrezi.AmeliyatId);
            foreach(var item in ameliyat)
            {
                var doktor = ApiService.GetDoktor(item.DoktorId);
                var hasta = ApiService.GetHasta(item.HastaId);
                doktorlar.AddRange(doktor);
                hastalar.AddRange(hasta);
            }
            
            viewModel.Doktorlar = doktorlar;
            viewModel.Hastalar = hastalar;
            viewModel.Ameliyatlar = ameliyat;

            viewModel.AnalAtreziss = AnalAtrezi;
            


            return View(viewModel);
        }

  
   
        public async Task<IActionResult> Delete(int id)
        {
            using var httpClient = new HttpClient();


            var response = await httpClient.DeleteAsync($"https://localhost:7207/api/AnalAtrezi/AnalAtreziDeleteById?id={id}");


            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction("AnalAtreziListesi");
            }
            else
            {

                var errorMessage = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, errorMessage);
                return RedirectToAction("AnalAtreziListesi");
            }


        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            using var httpClient = new HttpClient();

            var response = await httpClient.GetStringAsync($"https://localhost:7207/api/AnalAtrezi/GetByIdAnalAtrezi?id={id}");

            var analAtrezi = JsonConvert.DeserializeObject<AnalAtrezi>(response);

            return View("Edit", analAtrezi);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(AnalAtrezi analAtrezi)
        {
            using var httpClient = new HttpClient();

            var jsonContent = new StringContent(
                JsonConvert.SerializeObject(analAtrezi),
                Encoding.UTF8,
                "application/json"
            );

            await httpClient.PutAsync($"https://localhost:7207/api/AnalAtrezi/AnalAtreziUpdate", jsonContent);
            return RedirectToAction("AnalAtreziListesi");
        }
        /*private List<Hasta> GetHastaListesi()
        {
            using var httpClient = new HttpClient();

            var apiUrl = "https://localhost:7207/api/Hasta/GetAllHasta";
            var response = httpClient.GetStringAsync(apiUrl).Result;
            var hastaListesi = JsonConvert.DeserializeObject<List<Hasta>>(response);

            return hastaListesi;
        }
        private List<Ameliyat> GetAmeliyatListesi()
        {
            using var httpClient = new HttpClient();

            var apiUrl = "https://localhost:7207/api/Ameliyat/GetAllAmeliyat";
            var response = httpClient.GetStringAsync(apiUrl).Result;
            var ameliyatListesi = JsonConvert.DeserializeObject<List<Ameliyat>>(response);

            return ameliyatListesi;
        }
        private List<Doktor> GetDoktorListesi()
        {
            using var httpClient = new HttpClient();

            var apiUrl = "https://localhost:7207/api/Doktor/GetAllDoktor";
            var response = httpClient.GetStringAsync(apiUrl).Result;
            var doktorListesi = JsonConvert.DeserializeObject<List<Doktor>>(response);

            return doktorListesi;
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
        private List<Ameliyat> GetAmeliyat(int id)
        {
            using var httpClient = new HttpClient();

            var apiUrl = "https://localhost:7207/api/Ameliyat/GetAllAmeliyat";
            var response = httpClient.GetStringAsync(apiUrl).Result;

            // JSON formatı değiştiyse, aşağıdaki gibi deserializasyonu güncelleyin
            var ameliyat = JsonConvert.DeserializeObject<List<Ameliyat>>(response);
            var ameliyats = ameliyat.Where(a => a.Id == id).ToList();

            return ameliyats;

        }*/

    }
}
