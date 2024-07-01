using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAntiRefluDal : EfEntityRepositoryBase<AntiReflu, SurgiTrackContext>, IAntiRefluDal
    {

        public void DeleteById(int id)
        {
            using (SurgiTrackContext context = new())
            {
                var deletedEntity = context.Entry(context.Set<AntiReflu>().Find(id));
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

    }
}
