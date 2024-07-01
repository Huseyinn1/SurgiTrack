using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IHastaDal : IEntityRepository<Hasta>
    {
        void DeleteById(int id);
    }
}
