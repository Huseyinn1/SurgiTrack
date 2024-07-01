using Business.Abstract;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Business.Concrete
{
    public class DoktorManager : IDoktorService
    {
        

        IDoktorDal _doktorDal;
        
        public DoktorManager(IDoktorDal doktorDal)
        {
            _doktorDal = doktorDal;  
        }

        public void Add(Doktor doktor)
        {
            _doktorDal.Add(doktor);
        }

        public void DeleteById(int id)
        {
            _doktorDal.DeleteById(id);
        }

        public void Delete(Doktor doktor)
        {
            _doktorDal.Delete(doktor);
        }
        public List<Doktor> GetAll()
        {
           return _doktorDal.GetAll();
        }

        public Doktor GetById(int id)
        {
            return _doktorDal.Get(d => d.Id == id);
        }

        public void Update(Doktor doktor)
        {
            _doktorDal.Update(doktor);
        }
    }
}
