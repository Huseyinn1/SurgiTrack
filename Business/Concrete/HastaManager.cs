using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Business.Concrete
{
    public class HastaManager : IHastaService
    {
        

        IHastaDal _hastaDal;
        
        public HastaManager(IHastaDal hastaDal)
        {
            _hastaDal = hastaDal;  
        }

        public void Add(Hasta hasta)
        {
            _hastaDal.Add(hasta);
        }

        public void DeleteById(int id)
        {
            _hastaDal.DeleteById(id);
        }

        public void Delete(Hasta hasta)
        {
            _hastaDal.Delete(hasta);
        }
        public List<Hasta> GetAll()
        {
           return _hastaDal.GetAll();
        }

        public Hasta GetById(int id)
        {
            return _hastaDal.Get(d => d.Id == id);
        }

        public void Update(Hasta hasta)
        {
            _hastaDal.Update(hasta);
        }

        public List<Hasta> GetByCinsiyet(char cinsiyet)
        {
            return _hastaDal.GetAll(h=>h.Cinsiyet == cinsiyet);
        }
    }
}
