using Microsoft.AspNetCore.Mvc;
using SurgiTrackUI.Models;
using System.Diagnostics;
using System.Net.Http;

namespace SurgiTrackUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

    
        public async Task<IActionResult> IndexAsync()
        { 
            
            using var httpClient = new HttpClient();

            var apiUrl = "https://localhost:7207/api/GrafikVeTablo/GetChartData";
            var response = await httpClient.GetStringAsync(apiUrl);
            var chartData = Newtonsoft.Json.JsonConvert.DeserializeObject<ChartModel>(response);


            //string url = $"https://localhost:7207/api/GrafikVeTablo/GetChartData";
            //HttpResponseMessage responseStudenId = httpClient.GetAsync(url).Result;

             //= int.Parse(responseStudenId.Content.ReadAsStringAsync().Result);

            List<int> deger1 = new List<int> { 
                chartData.AnalAtzCount,
                chartData.AntiRCount,
                chartData.ApdCount, 
                chartData.DhCount,
                chartData.EVesCount , 
                chartData.KPErkCount,
                chartData.KPKadCount, };

            List<int> deger2 = new List<int> {
            chartData.HastaKizSayisi,
            chartData.HastaErkekSayisi
            };

            var chartProfileVisitData = GetChartProfileVisitData(deger1);
            var chartVisitorsProfileData = GetChartVisitorsProfileData(deger2);

            ViewBag.ChartProfileVisitData = chartProfileVisitData;
            ViewBag.ChartVisitorsProfileData = chartVisitorsProfileData;

            ViewBag.DoktorSayisi = chartData.DoktorSayisi;
            ViewBag.HastaSayisi = chartData.HastaSayisi;
            ViewBag.ToplamAmeliyatSayisi = chartData.ToplamAmeliyatSayisi;
            ViewBag.AmeliyatCesitiSayisi = chartData.AmeliyatCesitiSayisi;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        private Dictionary<string, object> GetChartProfileVisitData(List<int> deger)
        {
            // Burada istediğiniz gibi grafik verilerini oluşturabilirsiniz
            // Örneğin, verileri veritabanından alabilirsiniz
            var data = new Dictionary<string, object>
        {
            //{ "sales", new List<int> {25, 15, 5, 6, 4, 30, 28 } },
            { "sales", deger },
            { "categories", new List<string> { "AnalAtz", "AntiR", "Apd", "DH", "EVes", "KPErk", "KPKad" } }
        };

            return data;
        }

        private Dictionary<string, object> GetChartVisitorsProfileData(List<int> deger)
        {
            // Burada istediğiniz gibi chartVisitorsProfile verilerini oluşturabilirsiniz
            var data = new Dictionary<string, object>
        {
            //{ "series", new List<int> { 40, 60 } },
            { "series", deger },
            { "labels", new List<string> { "Kiz", "Erkek" } },
            { "colors", new List<string> { "#435ebe", "#55c6e8" } }
        };

            return data;
        }

        private class ChartModel
        {
            public int AnalAtzCount { get; set; }
            public int AntiRCount { get; set; }
            public int ApdCount { get; set; }
            public int DhCount { get; set; }
            public int EVesCount { get; set; }
            public int KPErkCount { get; set; }
            public int KPKadCount { get; set; }
            public int DoktorSayisi { get; set; }
            public int HastaSayisi { get; set; }
            public int ToplamAmeliyatSayisi { get; set; }
            public int AmeliyatCesitiSayisi { get; set; }
            public int HastaErkekSayisi { get; set; }
            public int HastaKizSayisi { get; set; }
        }
    }
}
