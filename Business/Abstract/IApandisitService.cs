using Entities.Concrete;

namespace Business.Abstract
{
    public interface IApandisitService
    {
        List<Apandisit> GetAll();
        void Add(Apandisit apandisit);
        void DeleteById(int id);
        void Delete(Apandisit apandisit);
        void Update(Apandisit apandisit);
        Apandisit GetById(int id);
    }
}
