using Core.Entities;

namespace Entities.Concrete
{
    public class AnalAtrezi : IEntity
    {
        public int Id { get; set; }
        public int AmeliyatId { get; set; }
        public string AmeliyatTipi { get; set; }
        public string GAA_PVI { get; set; }
        public string AnusYeriTespit { get; set; }
        public string InsizyonYapilmasi { get; set; }
        public string SfinkterKoruma { get; set; }
        public string PullThroughIslemi { get; set; }
        public string AnostomozYapilmasi { get; set; }
        public string KanamaKontrolu { get; set; }
        public string KomplikasyonDurumu { get; set; }
    }

}
