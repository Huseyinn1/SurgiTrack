using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class DiyafragmaHernisiManager : IDiyafragmaHernisiService
    {


        IDiyafragmaHernisiDal _diyafragmaHernisiDal;
        
        public DiyafragmaHernisiManager(IDiyafragmaHernisiDal diyafragmaHernisiDal)
        {
            _diyafragmaHernisiDal = diyafragmaHernisiDal;  
        }

        public void Add(DiyafragmaHernisi diyafragmaHernisi)
        {
            _diyafragmaHernisiDal.Add(diyafragmaHernisi);
        }

        public void DeleteById(int id)
        {
            _diyafragmaHernisiDal.DeleteById(id);
        }

        public void Delete(DiyafragmaHernisi diyafragmaHernisi)
        {
            _diyafragmaHernisiDal.Delete(diyafragmaHernisi);
        }
        public List<DiyafragmaHernisi> GetAll()
        {
           return _diyafragmaHernisiDal.GetAll();
        }

        public DiyafragmaHernisi GetById(int id)
        {
            return _diyafragmaHernisiDal.Get(d => d.Id == id);
        }

        public void Update(DiyafragmaHernisi diyafragmaHernisi)
        {
            _diyafragmaHernisiDal.Update(diyafragmaHernisi);
        }
    }
}
