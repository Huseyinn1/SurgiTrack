using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IKolonPullThroughErkekDal : IEntityRepository<KolonPullThroughErkek>
    {
        void DeleteById(int id);
    }
}
