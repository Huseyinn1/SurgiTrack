using Entities.Concrete;

namespace Business.Abstract
{
    public interface IAnalAtreziService
    {
        List<AnalAtrezi> GetAll();
        void Add(AnalAtrezi analAtrezi);
        void DeleteById(int id);
        void Delete(AnalAtrezi analAtrezi);
        void Update(AnalAtrezi analAtrezi);
        AnalAtrezi GetById(int id);
    }
}
