using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IKolonPullThroughKadinDal : IEntityRepository<KolonPullThroughKadin>
    {
        void DeleteById(int id);
    }
}
