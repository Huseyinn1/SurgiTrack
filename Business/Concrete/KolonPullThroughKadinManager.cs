using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class KolonPullThroughKadinManager : IKolonPullThroughKadinService
    {


        IKolonPullThroughKadinDal _kolonPullThroughKadinDal;
        
        public KolonPullThroughKadinManager(IKolonPullThroughKadinDal kolonPullThroughKadinDal)
        {
            _kolonPullThroughKadinDal = kolonPullThroughKadinDal;  
        }

        public void Add(KolonPullThroughKadin kolonPullThroughKadin)
        {
            _kolonPullThroughKadinDal.Add(kolonPullThroughKadin);
        }

        public void DeleteById(int id)
        {
            _kolonPullThroughKadinDal.DeleteById(id);
        }

        public void Delete(KolonPullThroughKadin kolonPullThroughKadin)
        {
            _kolonPullThroughKadinDal.Delete(kolonPullThroughKadin);
        }
        public List<KolonPullThroughKadin> GetAll()
        {
           return _kolonPullThroughKadinDal.GetAll();
        }

        public KolonPullThroughKadin GetById(int id)
        {
            return _kolonPullThroughKadinDal.Get(d => d.Id == id);
        }

        public void Update(KolonPullThroughKadin kolonPullThroughKadin)
        {
            _kolonPullThroughKadinDal.Update(kolonPullThroughKadin);
        }
    }
}
