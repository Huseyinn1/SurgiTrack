using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class KolonPullThroughErkekManager : IKolonPullThroughErkekService
    {


        IKolonPullThroughErkekDal _kolonPullThroughErkekDal;
        
        public KolonPullThroughErkekManager(IKolonPullThroughErkekDal kolonPullThroughErkekDal)
        {
            _kolonPullThroughErkekDal = kolonPullThroughErkekDal;  
        }

        public void Add(KolonPullThroughErkek kolonPullThroughErkek)
        {
            _kolonPullThroughErkekDal.Add(kolonPullThroughErkek);
        }

        public void DeleteById(int id)
        {
            _kolonPullThroughErkekDal.DeleteById(id);
        }

        public void Delete(KolonPullThroughErkek kolonPullThroughErkek)
        {
            _kolonPullThroughErkekDal.Delete(kolonPullThroughErkek);
        }
        public List<KolonPullThroughErkek> GetAll()
        {
           return _kolonPullThroughErkekDal.GetAll();
        }

        public KolonPullThroughErkek GetById(int id)
        {
            return _kolonPullThroughErkekDal.Get(d => d.Id == id);
        }

        public void Update(KolonPullThroughErkek kolonPullThroughErkek)
        {
            _kolonPullThroughErkekDal.Update(kolonPullThroughErkek);
        }
    }
}
