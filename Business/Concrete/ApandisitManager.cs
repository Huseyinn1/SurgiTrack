using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ApandisitManager : IApandisitService
    {


        IApandisitDal _apandisitDal;
        
        public ApandisitManager(IApandisitDal apandisitDal)
        {
            _apandisitDal = apandisitDal;  
        }

        public void Add(Apandisit apandisit)
        {
            _apandisitDal.Add(apandisit);
        }

        public void DeleteById(int id)
        {
            _apandisitDal.DeleteById(id);
        }

        public void Delete(Apandisit apandisit)
        {
            _apandisitDal.Delete(apandisit);
        }
        public List<Apandisit> GetAll()
        {
           return _apandisitDal.GetAll();
        }

        public Apandisit GetById(int id)
        {
            return _apandisitDal.Get(d => d.Id == id);
        }

        public void Update(Apandisit apandisit)
        {
            _apandisitDal.Update(apandisit);
        }
    }
}
