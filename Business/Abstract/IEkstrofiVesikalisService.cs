using Entities.Concrete;

namespace Business.Abstract
{
    public interface IEkstrofiVesikalisService
    {
        List<EkstrofiVesikalis> GetAll();
        void Add(EkstrofiVesikalis ekstrofiVesikalis);
        void DeleteById(int id);
        void Delete(EkstrofiVesikalis ekstrofiVesikalis);
        void Update(EkstrofiVesikalis ekstrofiVesikalis);
        EkstrofiVesikalis GetById(int id);
    }
}
