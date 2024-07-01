using Entities.Concrete;

namespace Business.Abstract
{
    public interface IKolonPullThroughErkekService
    {
        List<KolonPullThroughErkek> GetAll();
        void Add(KolonPullThroughErkek kolonPullThroughErkek);
        void DeleteById(int id);
        void Delete(KolonPullThroughErkek kolonPullThroughErkek);
        void Update(KolonPullThroughErkek kolonPullThroughErkek);
        KolonPullThroughErkek GetById(int id);
    }
}
