using Entities.Concrete;

namespace Business.Abstract
{
    public interface IAmeliyatService
    {
        List<Ameliyat> GetAll();
        List<Ameliyat> GetLast30Day();
        void Add(Ameliyat ameliyat);
        void DeleteById(int id);
        void Delete(Ameliyat ameliyat);
        void Update(Ameliyat ameliyat);
        Ameliyat GetById(int id);
    }
}
