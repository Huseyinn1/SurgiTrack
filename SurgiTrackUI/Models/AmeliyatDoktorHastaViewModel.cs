namespace SurgiTrackUI.Models
{
    public class AmeliyatDoktorHastaViewModel
    {
        public Ameliyat Ameliyatlar { get; set; } = new();
        public List<Doktor> doktor { get; set; }
        public List<Hasta> hasta { get; set; }
    }
}
