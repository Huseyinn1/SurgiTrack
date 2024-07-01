using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class EkstrofiVesikalisManager : IEkstrofiVesikalisService
    {


        IEkstrofiVesikalisDal _ekstrofiVesikalisDal;
        
        public EkstrofiVesikalisManager(IEkstrofiVesikalisDal ekstrofiVesikalisDal)
        {
            _ekstrofiVesikalisDal = ekstrofiVesikalisDal;  
        }

        public void Add(EkstrofiVesikalis ekstrofiVesikalis)
        {
            _ekstrofiVesikalisDal.Add(ekstrofiVesikalis);
        }

        public void DeleteById(int id)
        {
            _ekstrofiVesikalisDal.DeleteById(id);
        }

        public void Delete(EkstrofiVesikalis ekstrofiVesikalis)
        {
            _ekstrofiVesikalisDal.Delete(ekstrofiVesikalis);
        }
        public List<EkstrofiVesikalis> GetAll()
        {
           return _ekstrofiVesikalisDal.GetAll();
        }

        public EkstrofiVesikalis GetById(int id)
        {
            return _ekstrofiVesikalisDal.Get(d => d.Id == id);
        }

        public void Update(EkstrofiVesikalis ekstrofiVesikalis)
        {
            _ekstrofiVesikalisDal.Update(ekstrofiVesikalis);
        }
    }
}
