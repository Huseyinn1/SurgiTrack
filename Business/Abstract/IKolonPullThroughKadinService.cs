using Entities.Concrete;

namespace Business.Abstract
{
    public interface IKolonPullThroughKadinService
    {
        List<KolonPullThroughKadin> GetAll();
        void Add(KolonPullThroughKadin kolonPullThroughKadin);
        void DeleteById(int id);
        void Delete(KolonPullThroughKadin kolonPullThroughKadin);
        void Update(KolonPullThroughKadin kolonPullThroughKadin);
        KolonPullThroughKadin GetById(int id);
    }
}
