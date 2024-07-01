using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IAntiRefluDal : IEntityRepository<AntiReflu>
    {
        void DeleteById(int id);
    }
}
