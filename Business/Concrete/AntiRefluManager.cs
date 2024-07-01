using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class AntiRefluManager : IAntiRefluService
    {


        IAntiRefluDal _antiRefluDal;
        
        public AntiRefluManager(IAntiRefluDal antiRefluDal)
        {
            _antiRefluDal = antiRefluDal;  
        }

        public void Add(AntiReflu antiReflu)
        {
            _antiRefluDal.Add(antiReflu);
        }

        public void DeleteById(int id)
        {
            _antiRefluDal.DeleteById(id);
        }

        public void Delete(AntiReflu antiReflu)
        {
            _antiRefluDal.Delete(antiReflu);
        }
        public List<AntiReflu> GetAll()
        {
           return _antiRefluDal.GetAll();
        }

        public AntiReflu GetById(int id)
        {
            return _antiRefluDal.Get(d => d.Id == id);
        }

        public void Update(AntiReflu antiReflu)
        {
            _antiRefluDal.Update(antiReflu);
        }
    }
}
