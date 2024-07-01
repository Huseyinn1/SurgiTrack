namespace SurgiTrackUI.Models
{
    public class AmeliyatListViewModel
    {
        public List<Ameliyat> Ameliyatlar { get; set; }= new ();
        public List<Doktor> Doktorlar { get; set; } = new();
        public List<Hasta> Hastalar { get; set; } = new();
        public List<AnalAtrezi> AnalAtrezis { get; set; } = new();
        public List<AntiReflu> AntiReflus { get; set; } = new();
        public AntiReflu antiReflu { get; set; } = new();
        public List<Apandisit> Apandisits { get; set; } = new();
        public List<DiyafragmaHernisi> DiyafragmaHernisis { get; set; } = new();
        public List<EkstrofiVesikalis> EkstrofiVesikaliss { get; set; } = new();
        public List<KolonPullThroughErkek> KolonPullThroughErkeks { get; set; } = new();
        public List<KolonPullThroughKadin> KolonPullThroughKadins { get; set; } = new();
        public Ameliyat? Ameliyatlarr { get; set; }
        public AnalAtrezi ? AnalAtreziss { get; set; }
        public AntiReflu? AntiRefluss { get; set; }
        public Apandisit? Apandisitss { get; set; }
        public DiyafragmaHernisi? DiyafragmaHernisiss { get; set; }
        public EkstrofiVesikalis? EkstrofiVesikalisss { get; set; }
        public KolonPullThroughErkek? KolonPullThroughErkekss { get; set; }
        public KolonPullThroughKadin? KolonPullThroughKadinss { get; set; }
    }
}
