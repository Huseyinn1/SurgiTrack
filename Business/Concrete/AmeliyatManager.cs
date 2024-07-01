using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class AmeliyatManager : IAmeliyatService
    {


        IAmeliyatDal _ameliyatDal;
        
        public AmeliyatManager(IAmeliyatDal ameliyatDal)
        {
            _ameliyatDal = ameliyatDal;  
        }

        public void Add(Ameliyat ameliyat)
        {
            _ameliyatDal.Add(ameliyat);
        }

        public void DeleteById(int id)
        {
            _ameliyatDal.DeleteById(id);
        }

        public void Delete(Ameliyat ameliyat)
        {
            _ameliyatDal.Delete(ameliyat);
        }
        public List<Ameliyat> GetAll()
        {
           return _ameliyatDal.GetAll();
        }

        public Ameliyat GetById(int id)
        {
            return _ameliyatDal.Get(d => d.Id == id);
        }

        public void Update(Ameliyat ameliyat)
        {
            _ameliyatDal.Update(ameliyat);
        }

        public List<Ameliyat> GetLast30Day()
        {
            DateTime today = DateTime.Now;
            DateTime thresholdDate = today.AddDays(-30);
            
            return _ameliyatDal.GetAll(a => DateTime.Parse(a.AmeliyatTarihi) >= thresholdDate && DateTime.Parse(a.AmeliyatTarihi) <= today);

        }
    }
}
