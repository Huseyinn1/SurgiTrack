namespace SurgiTrackUI.Models
{
    public class Doktor
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public char Cinsiyet { get; set; }
        public string Telefon { get; set; }
        public string Eposta { get; set; }
        public DateTime  KayitTarihi = DateTime.Now;
    }
}
