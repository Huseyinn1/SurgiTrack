using Core.Entities;

namespace Entities.Concrete
{
    public class Ameliyat : IEntity
    {
        public int Id { get; set; }       
        public int HastaId { get; set; }       
        public int DoktorId { get; set; }       
        public string AmeliyatAdi { get; set; }
        public string AmeliyatTarihi { get; set; }       
    }

    }
