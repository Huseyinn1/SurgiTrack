using Core.Entities;

namespace Entities.Concrete
{
    public class Apandisit : IEntity
    {
        public int Id { get; set; }
        public int AmeliyatId { get; set; }
        public string AmeliyatTipi { get; set; }
        public string AmeliyatYapilanBolge { get; set; }
        public string GAA_PVI { get; set; }
        public string ApandisitTesbit { get; set; }
        public string ApandiksSerbest { get; set; }
        public string ApandektomiYapilmasi { get; set; }
        public string PeritonealLavaj { get; set; }
        public string PeritonKapatma { get; set; }
        public string AdaleSuturleriYaklastirma { get; set; }
        public string CiltDikilmesi { get; set; }
        public string KanamaKontrolu { get; set; }
        public string KomplikasyonDurumu { get; set; }
    }





}
