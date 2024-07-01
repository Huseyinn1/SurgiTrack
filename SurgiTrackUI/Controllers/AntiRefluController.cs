using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SurgiTrackUI.Models;
using System.Collections.Generic;
using System.Text;

namespace SurgiTrackUI.Controllers
{
    public class AntiRefluController : Controller
    {
        public IActionResult AntiReflu()
        {
            return View();
        }
        //public IActionResult AntiRefluAdd()
        //{
        //    var viewModel = new AmeliyatListViewModel
        //    {

        //        Ameliyatlar = GetAmeliyats()

        //    };

        //    return View(viewModel);
        //}
        //[HttpPost]
        //public async Task<IActionResult> AntiRefluAdd(AntiReflu AntiReflu)
        //{

        //    using var httpClient = new HttpClient();

        //    var jsonContent = new StringContent(
        //        JsonConvert.SerializeObject(AntiReflu),
        //        Encoding.UTF8,
        //        "application/json"
        //    );
        //    await httpClient.PostAsync("https://localhost:7207/api/AntiReflu/AntiRefluAdd", jsonContent);

        //    return View();
        //}
        



        public async Task<IActionResult> Add()
        {
            List<Ameliyat> ameliyatlar = await GetAmeliyats();

            List<AmeliyatDto> ameliyatlarDtos = new List<AmeliyatDto>();

            for (int i = 0; i < ameliyatlar.Count(); i++)
            {
                AmeliyatDto ameliyatDto = new();
                ameliyatDto.Id = ameliyatlar[i].Id;
                ameliyatDto.AmeliyatName = ameliyatlar[i].AmeliyatAdi;
                ameliyatDto.HastaName = (await GetHastaAdi(ameliyatlar[i].HastaId)).Ad;
                ameliyatDto.HastaSurname = (await GetHastaAdi(ameliyatlar[i].HastaId)).Soyad;

                ameliyatlarDtos.Add(ameliyatDto);
            }

            ViewBag.Ameliyatlar = ameliyatlarDtos;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AntiReflu antiReflu)
        {
            using var httpClient = new HttpClient();

            var jsonContent = new StringContent(
                JsonConvert.SerializeObject(antiReflu),
                Encoding.UTF8,
                "application/json"
            );
            await httpClient.PostAsync("https://localhost:7207/api/AntiReflu/AntiRefluAdd", jsonContent);

            // İşlem tamamlandıktan sonra bir sonraki adıma yönlendir
            // return RedirectToAction("NextAvction"); // "NextAction" kısmını kendi ihtiyacınıza göre değiştirin

            return View();
        }
        private async Task<List<Ameliyat>> GetAmeliyats()
        {
            using var httpClient = new HttpClient();

            var apiUrl = "https://localhost:7207/api/Ameliyat/GetAllAmeliyat";
            var response = await httpClient.GetStringAsync(apiUrl);
            var ameliyats = JsonConvert.DeserializeObject<List<Ameliyat>>(response);

            return ameliyats;
        }

        private async Task<Hasta> GetHastaAdi(int id)
        {
            using var httpClient = new HttpClient();

            var apiUrl = $"https://localhost:7207/api/Hasta/GetByIdHasta?id={id}";
            var response = await httpClient.GetStringAsync(apiUrl);

            var hasta = JsonConvert.DeserializeObject<Hasta>(response);

            return hasta;
        }


        public async Task<IActionResult> AntiRefluListesi()
        {
            using var httpClient = new HttpClient();


            var search = HttpContext.Request.Query["search"].ToString();


            var apiUrl = "https://localhost:7207/api/AntiReflu/GetAllAntiReflu";

            var response = await httpClient.GetStringAsync(apiUrl);


            var AntiRefluListesi = JsonConvert.DeserializeObject<List<AntiReflu>>(response);


            return View(AntiRefluListesi);
        }
        //public async Task<IActionResult> TekilAntiReflu(int id)
        //{
        //    using var httpClient = new HttpClient();

        //    var response = await httpClient.GetStringAsync($"https://localhost:7207/api/AntiReflu/GetByIdAntiReflu?id={id}");

        //    var AntiReflu = JsonConvert.DeserializeObject<AntiReflu>(response);

        //    return View(AntiReflu);
        //}
        public async Task<IActionResult> TekilAntiReflu(AmeliyatListViewModel viewModel, int id)
        {
            using var httpClient = new HttpClient();

            var response = await httpClient.GetStringAsync($"https://localhost:7207/api/AntiReflu/GetByIdAntiReflu?id={id}");

            var antiReflu = JsonConvert.DeserializeObject<AntiReflu>(response);

            var doktorlar = new List<Doktor>();
            var hastalar = new List<Hasta>();
            var ameliyat = ApiService.GetAmeliyat(antiReflu.AmeliyatId);
            foreach (var item in ameliyat)
            {
                var doktor = ApiService.GetDoktor(item.DoktorId);
                var hasta = ApiService.GetHasta(item.HastaId);
                doktorlar.AddRange(doktor);
                hastalar.AddRange(hasta);
            }

            viewModel.Doktorlar = doktorlar;
            viewModel.Hastalar = hastalar;
            viewModel.Ameliyatlar = ameliyat;

            viewModel.antiReflu = antiReflu;



            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            using var httpClient = new HttpClient();


            var response = await httpClient.DeleteAsync($"https://localhost:7207/api/AntiReflu/AntiRefluDeleteById?id={id}");


            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction("AntiRefluListesi");
            }
            else
            {

                var errorMessage = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, errorMessage);
                return RedirectToAction("AntiRefluListesi");
            }


        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            using var httpClient = new HttpClient();

            var response = await httpClient.GetStringAsync($"https://localhost:7207/api/AntiReflu/GetByIdAntiReflu?id={id}");

            var AntiReflu = JsonConvert.DeserializeObject<AntiReflu>(response);



            List<Ameliyat> ameliyatlar = await GetAmeliyats();

            List<AmeliyatDto> ameliyatlarDtos = new List<AmeliyatDto>();

            for (int i = 0; i < ameliyatlar.Count(); i++)
            {
                AmeliyatDto ameliyatDto = new();
                ameliyatDto.Id = ameliyatlar[i].Id;
                ameliyatDto.AmeliyatName = ameliyatlar[i].AmeliyatAdi;
                ameliyatDto.HastaName = (await GetHastaAdi(ameliyatlar[i].HastaId)).Ad;
                ameliyatDto.HastaSurname = (await GetHastaAdi(ameliyatlar[i].HastaId)).Soyad;
                ameliyatlarDtos.Add(ameliyatDto);
            }

            ViewBag.Ameliyatlar = ameliyatlarDtos;

            ViewBag.AntiReflu = AntiReflu;

            //return View("Edit", AntiReflu);
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Edit(AntiReflu AntiReflu)
        {
            using var httpClient = new HttpClient();

            var jsonContent = new StringContent(
                JsonConvert.SerializeObject(AntiReflu),
                Encoding.UTF8,
                "application/json"
            );

            await httpClient.PutAsync($"https://localhost:7207/api/AntiReflu/AntiRefluUpdate", jsonContent);
            return RedirectToAction("AntiRefluListesi");           
        }



      
    }
}