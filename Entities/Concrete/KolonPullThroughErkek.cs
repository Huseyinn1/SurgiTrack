using Core.Entities;

namespace Entities.Concrete
{
    public class KolonPullThroughErkek : IEntity
    {
        public int Id { get; set; }
        public int AmeliyatId { get; set; }
        public string AmeliyatTipi { get; set; }
        public string AmeliyatYapilanBolge { get; set; }
        public string AmeliyatYontemi { get; set; }
        public string GAA_PVI { get; set; }
        public string RektumAskiyaAlma { get; set; }
        public string UretraKateterizasyon { get; set; }
        public string RektumDiseksiyonu { get; set; }
        public string AnusSfinterKoruma { get; set; }
        public string PullThroughIslemi { get; set; }
        public string AnostomozYapilmasi { get; set; }
        public string KanamaKontrolu { get; set; }
        public string KomplikasyonDurumu { get; set; }
    }



}
