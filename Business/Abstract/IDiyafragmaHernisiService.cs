using Entities.Concrete;

namespace Business.Abstract
{
    public interface IDiyafragmaHernisiService
    {
        List<DiyafragmaHernisi> GetAll();
        void Add(DiyafragmaHernisi diyafragmaHernisi);
        void DeleteById(int id);
        void Delete(DiyafragmaHernisi diyafragmaHernisi);
        void Update(DiyafragmaHernisi diyafragmaHernisi);
        DiyafragmaHernisi GetById(int id);
    }
}
