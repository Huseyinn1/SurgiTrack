using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDoktorService
    {
        List<Doktor> GetAll();
        void Add(Doktor doktor);
        void DeleteById(int id);
        void Delete(Doktor doktor);
        void Update(Doktor doktor); 
        Doktor GetById(int id);
    }
}
