using Microsoft.Extensions.Hosting;
using TitanServices.DTO;
using TitanServices.Helper;
using TitanServices.Models;

namespace TitanServices.Services
{
    public class SliderTypeService : ISliderTypeService
    {
        private readonly SliderTypeContext _sliderTypeContext;

        public SliderTypeService(SliderTypeContext sliderTypeContext)
        {
            _sliderTypeContext = sliderTypeContext;
        }

        public SliderType Create(SliderType sliderType)
        {
            if(_sliderTypeContext.SliderTypes.Any(x => x.Title == sliderType.Title))
                throw  new AppException("Title type \"" + sliderType.Title +"\" is already exists");
            _sliderTypeContext.SliderTypes.Add(sliderType);
            _sliderTypeContext.SaveChanges();
            return sliderType;
        }

        public IEnumerable<SliderType> createsMany()
        {
            var sliderTypes = new SliderType[]
            {
                new SliderType{Title="BANNER",Description="Banner"},
                new SliderType{Title="DOMAINS & TECHNOLOGIES", Description="DOMAINS & TECHNOLOGIES"},
                new SliderType{Title="WE PROVIDE", Description="Professional and trusted services with cost-effective and exceptional expertise to deal with any complexities in scalable projects"},
                new SliderType{Title="OUR CLIENTS", Description="OUR CLIENTS"},
                new SliderType{Title="CUSTOMER TESTIMONIALS",Description="We deeply appreciate all feedbacks from our customers and keep those as realistic results of high-quality service in Titan"},
                new SliderType{Title="As Recognized By", Description="As Recognized By"}
            };

            foreach (var sliderType in sliderTypes)
            {
                _sliderTypeContext.SliderTypes.Add(sliderType);
            }
            _sliderTypeContext.SaveChanges();
            return sliderTypes;
        }

        public void Delete(string id)
        {
            var sliderType = _sliderTypeContext.SliderTypes.Find(id);
            if(sliderType != null)
            {
                _sliderTypeContext.SliderTypes.Remove(sliderType);
                _sliderTypeContext.SaveChanges();
            }
        }

        public IEnumerable<SliderType> GetAll()
        {
            if(_sliderTypeContext.SliderTypes == null) return Enumerable.Empty<SliderType>();
            return _sliderTypeContext.SliderTypes;
        }

        public SliderType GetById(string id)
        {
            return _sliderTypeContext.SliderTypes.Find(id);
        }   

        public void Update(SliderType sliderTypeParam)
        {
            var sliderType = _sliderTypeContext.SliderTypes.Find(sliderTypeParam._id);
            if(sliderType != null )
            {
                throw new AppException("SliderType not found");
            }

            sliderType = sliderTypeParam;
            _sliderTypeContext.SliderTypes.Update(sliderType);
            _sliderTypeContext.SaveChanges();
        }
    }
}
