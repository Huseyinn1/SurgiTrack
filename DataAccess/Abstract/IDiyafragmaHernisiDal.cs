using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IDiyafragmaHernisiDal : IEntityRepository<DiyafragmaHernisi>
    {
        void DeleteById(int id);
    }
}
