using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrafikVeTabloController : ControllerBase
    {
        IHastaService _hastaService;
        IDoktorService _doktorService;
        IAmeliyatService _ameliyatService;

        IAnalAtreziService _analAtreziService;
        IAntiRefluService _antiRefluService;
        IApandisitService _apandisitService;
        IDiyafragmaHernisiService _diyafragmaHernisiService;
        IEkstrofiVesikalisService _ekstrofiVesikalisService;
        IKolonPullThroughErkekService _kolonPullThroughErkekService;
        IKolonPullThroughKadinService _kolonPullThroughKadinService;


        public GrafikVeTabloController(IAmeliyatService ameliyatService, IDoktorService doktorService, IHastaService hastaService,
            IAnalAtreziService analAtreziService,
            IAntiRefluService antiRefluService,
            IApandisitService apandisitService,
            IDiyafragmaHernisiService diyafragmaHernisiService,
            IEkstrofiVesikalisService ekstrofiVesikalisService,
            IKolonPullThroughErkekService kolonPullThroughErkekService,
            IKolonPullThroughKadinService kolonPullThroughKadinService
            )
        {
            _hastaService = hastaService;
            _doktorService = doktorService;
            _ameliyatService = ameliyatService;

            _analAtreziService = analAtreziService;
            _antiRefluService = antiRefluService;
            _apandisitService = apandisitService;
            _diyafragmaHernisiService = diyafragmaHernisiService;
            _ekstrofiVesikalisService = ekstrofiVesikalisService;
            _kolonPullThroughErkekService = kolonPullThroughErkekService;
            _kolonPullThroughKadinService = kolonPullThroughKadinService;
        }

        [HttpGet("GetChartData")]
        public IActionResult GetChartData()

        {
            try
            {
                ChartData chartData = new ChartData();
                chartData.analAtzCount = _analAtreziService.GetAll().Count();
                chartData.antiRCount = _antiRefluService.GetAll().Count();
                chartData.apdCount = _apandisitService.GetAll().Count();
                chartData.dhCount = _diyafragmaHernisiService.GetAll().Count();
                chartData.eVesCount = _ekstrofiVesikalisService.GetAll().Count();
                chartData.kPErkCount = _kolonPullThroughErkekService.GetAll().Count();
                chartData.kPKadCount = _kolonPullThroughKadinService.GetAll().Count();

                ;
                chartData.HastaSayisi = _hastaService.GetAll().Count();
                chartData.DoktorSayisi = _doktorService.GetAll().Count();
                // son 30 gün 
                //chartData.ToplamAmeliyatSayisi = _ameliyatService.GetLast30Day().Count(); 
                chartData.ToplamAmeliyatSayisi = _ameliyatService.GetAll().Count();
                chartData.AmeliyatCesitiSayisi = 7;

                int HastaErkekSayisi = _hastaService.GetByCinsiyet('E').Count();
                int ToplamHastaSayisi = _hastaService.GetAll().Count();

                chartData.HastaErkekSayisi = (100 * HastaErkekSayisi) / ToplamHastaSayisi;
                chartData.HastaKizSayisi = 100 - chartData.HastaErkekSayisi;
                return Ok(chartData);

            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        private class ChartData
        {
            public int analAtzCount { get; set; }
            public int antiRCount { get; set; }
            public int apdCount { get; set; }
            public int dhCount { get; set; }
            public int eVesCount { get; set; }
            public int kPErkCount { get; set; }
            public int kPKadCount { get; set; }
            public int DoktorSayisi { get; set; }
            public int HastaSayisi { get; set; }
            public int ToplamAmeliyatSayisi { get; set; }
            public int AmeliyatCesitiSayisi { get; set; }
            public int HastaErkekSayisi { get; set; }
            public int HastaKizSayisi { get; set; }
        }
    }
}
