using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IApandisitDal : IEntityRepository<Apandisit>
    {
        void DeleteById(int id);
    }
}
