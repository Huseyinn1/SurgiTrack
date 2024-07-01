using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfKolonPullThroughKadinDal : EfEntityRepositoryBase<KolonPullThroughKadin, SurgiTrackContext>, IKolonPullThroughKadinDal
    {

        public void DeleteById(int id)
        {
            using (SurgiTrackContext context = new())
            {
                var deletedEntity = context.Entry(context.Set<KolonPullThroughKadin>().Find(id));
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

    }
}
