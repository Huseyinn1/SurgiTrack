using Entities.Concrete;

namespace Business.Abstract
{
    public interface IAntiRefluService
    {
        List<AntiReflu> GetAll();
        void Add(AntiReflu antiReflu);
        void DeleteById(int id);
        void Delete(AntiReflu antiReflu);
        void Update(AntiReflu antiReflu);
        AntiReflu GetById(int id);
    }
}
