using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IAmeliyatDal : IEntityRepository<Ameliyat>
    {
        void DeleteById(int id);
    }
}
