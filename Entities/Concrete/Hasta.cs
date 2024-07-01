using Core.Entities;

namespace Entities.Concrete
{
    public class Hasta : IEntity
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public char Cinsiyet { get; set; }
        public string DogumTarihi { get; set; }
        public string Telefon { get; set; }
        public string Eposta { get; set; }
        public string Adres { get; set; }
        public string KayitTarihi { get; set; }

    }
}
