using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfApandisitDal : EfEntityRepositoryBase<Apandisit, SurgiTrackContext>, IApandisitDal
    {

        public void DeleteById(int id)
        {
            using (SurgiTrackContext context = new())
            {
                var deletedEntity = context.Entry(context.Set<Apandisit>().Find(id));
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

    }
}
