using TitanServices.Models;

namespace TitanServices.Services
{
    public interface ISliderTypeService
    {
        IEnumerable<SliderType> GetAll();
        SliderType GetById(string id);
        SliderType Create(SliderType sliderType);
        void Update(SliderType sliderType);
        void Delete(string id);
        IEnumerable<SliderType> createsMany();
    }
}
