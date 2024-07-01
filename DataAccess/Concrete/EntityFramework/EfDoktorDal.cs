using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfDoktorDal : EfEntityRepositoryBase<Doktor, SurgiTrackContext>, IDoktorDal
    {

        public void DeleteById(int id)
        {
            using (SurgiTrackContext context = new())
            {
                var deletedEntity = context.Entry(context.Set<Doktor>().Find(id));
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

    }
}
