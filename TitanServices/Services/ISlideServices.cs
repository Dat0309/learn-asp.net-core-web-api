using TitanServices.Models;

namespace TitanServices.Services
{
    public interface ISlideServices
    {
        IEnumerable<SliderModel> GetAll();
        SliderModel GetById(string id);
        SliderModel Create(SliderModel slider);
        void Update(SliderModel slider);
        void Delete(string id);
        IEnumerable<SliderModel> createsMany();
    }
}
