namespace SurgiTrackUI.Models
{

    public class AmeliyatViewModel
    {
        public Ameliyat? Ameliyat { get; set; }
        public List<Doktor> Doktorlar { get; set; } = new();
        public List<Hasta> Hastalar { get; set; } = new();
        public AnalAtrezi? AnalAtreziss { get; set; }
        public AntiReflu? AntiRefluss { get; set; }
        public Apandisit? Apandisitss { get; set; }
        public DiyafragmaHernisi? DiyafragmaHernisiss { get; set; }
        public EkstrofiVesikalis? EkstrofiVesikalisss { get; set; }
        public KolonPullThroughErkek? KolonPullThroughErkekss { get; set; }
        public KolonPullThroughKadin? KolonPullThroughKadinss { get; set; }
    }
}
