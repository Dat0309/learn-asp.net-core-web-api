using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SONRISA_BACKEND.Models;

namespace SONRISA_BACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {

        private readonly ProductCategoriesContext _context;
        public ProductCategoriesController(ProductCategoriesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCategories>>> GetProductCategories()
        {
            if(_context.ProductCategories == null)
            {
                return NotFound();
            }
            return await _context.ProductCategories.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCategories>> GetProductCategory(string id)
        {
            if(_context.ProductCategories == null)
            {
                return NotFound();
            }
            var productCategory = await _context.ProductCategories.FindAsync(id);
            if(productCategory == null)
            {
                return NotFound();
            }
            return productCategory;
        }

        [HttpPost]
        public async Task<ActionResult<ProductCategories>> CreateProductCategories(ProductCategories productCategories)
        {
            _context.ProductCategories.Add(productCategories);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductCategories), new {id = productCategories.ID},productCategories);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProductCategory(string id, ProductCategories productCategories)
        {
            if(id != productCategories.ID)
            {
                return BadRequest();
            }

            _context.Entry(productCategories).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                throw;
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductCategory(string id)
        {
            if(_context.ProductCategories == null)
            {
                return NotFound();
            }
            var productCategory = await _context.ProductCategories.FindAsync(id);
            if(productCategory == null)
            {
                return NotFound();
            }

            _context.ProductCategories.Remove(productCategory);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
