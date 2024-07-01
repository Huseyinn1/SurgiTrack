using Core.Entities;

namespace Entities.Concrete
{
    public class DiyafragmaHernisi : IEntity
    {
        public int Id { get; set; }
        public int AmeliyatId { get; set; }
        public string AmeliyatTipi { get; set; }
        public string GAA_PVI { get; set; }
        public string InsizyonYapilmasi { get; set; }
        public string DefektOnarimi { get; set; }
        public string KanamaKontrolu { get; set; }
        public string KomplikasyonDurumu { get; set; }
    }

}
