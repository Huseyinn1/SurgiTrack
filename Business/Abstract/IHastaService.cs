using Entities.Concrete;

namespace Business.Abstract
{
    public interface IHastaService
    {
        List<Hasta> GetAll();
        List<Hasta> GetByCinsiyet(char cinsiyet);
        void Add(Hasta hasta);
        void DeleteById(int id);
        void Delete(Hasta hasta);
        void Update(Hasta hasta); 
        Hasta GetById(int id);
    }
}
