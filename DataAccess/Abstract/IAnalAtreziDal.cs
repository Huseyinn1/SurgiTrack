using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IAnalAtreziDal : IEntityRepository<AnalAtrezi>
    {
        void DeleteById(int id);
    }
}
