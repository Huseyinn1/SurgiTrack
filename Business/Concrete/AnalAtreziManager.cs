using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class AnalAtreziManager : IAnalAtreziService
    {


        IAnalAtreziDal _analAtreziDal;
        
        public AnalAtreziManager(IAnalAtreziDal analAtreziDal)
        {
            _analAtreziDal = analAtreziDal;  
        }

        public void Add(AnalAtrezi analAtrezi)
        {
            _analAtreziDal.Add(analAtrezi);
        }

        public void DeleteById(int id)
        {
            _analAtreziDal.DeleteById(id);
        }

        public void Delete(AnalAtrezi analAtrezi)
        {
            _analAtreziDal.Delete(analAtrezi);
        }
        public List<AnalAtrezi> GetAll()
        {
           return _analAtreziDal.GetAll();
        }

        public AnalAtrezi GetById(int id)
        {
            return _analAtreziDal.Get(d => d.Id == id);
        }

        public void Update(AnalAtrezi analAtrezi)
        {
            _analAtreziDal.Update(analAtrezi);
        }
    }
}
