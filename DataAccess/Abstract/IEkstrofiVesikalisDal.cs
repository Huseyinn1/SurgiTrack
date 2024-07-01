using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IEkstrofiVesikalisDal : IEntityRepository<EkstrofiVesikalis>
    {
        void DeleteById(int id);
    }
}
