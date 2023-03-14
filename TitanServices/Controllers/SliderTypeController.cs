using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TitanServices.Entity;
using TitanServices.Helper;
using TitanServices.Models;
using TitanServices.Services;

namespace TitanServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderTypeController : ControllerBase
    {
        private ISliderTypeService _sliderTypeService;
        private IMapper _mapper;

        public SliderTypeController(ISliderTypeService sliderTypeService, IMapper mapper)
        {
            this._sliderTypeService = sliderTypeService;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll() {
            var sliderType = _sliderTypeService.GetAll();
            return Ok(sliderType);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id) {
            var sliderType = _sliderTypeService.GetById(id);
            return Ok(sliderType);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] UpdateSliderType model) {
            var sliderType = _mapper.Map<SliderType>(model);
            sliderType._id = id;

            try
            {
                _sliderTypeService.Update(sliderType);
                return Ok();
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _sliderTypeService.Delete(id);
            return Ok();
        }
    }
}
