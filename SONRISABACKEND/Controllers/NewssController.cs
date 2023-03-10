using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SONRISA_BACKEND.Models;

namespace SONRISA_BACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewssController : ControllerBase
    {
        private readonly NewsContext _newsContext;

        public NewssController(NewsContext newsContext)
        {
            _newsContext = newsContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<News>>> GetNewss()
        {
            if (_newsContext.News == null)
            {
                return NotFound();
            }
            return await _newsContext.News.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<News>> GetNews(string id)
        {
            if (_newsContext.News == null)
            {
                return NotFound();
            }
            var news = await _newsContext.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }
            return news;
        }

        [HttpPost]
        public async Task<ActionResult<News>> Createnews(News news)
        {
            _newsContext.News.Add(news);
            await _newsContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNews), new { id = news.ID }, news);
        }

        [HttpPut]
        public async Task<ActionResult> Putnews(string id, News news)
        {
            if (id != news.ID)
            {
                return BadRequest();
            }

            _newsContext.Entry(news).State = EntityState.Modified;
            try
            {
                await _newsContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Deletenews(string id)
        {
            if (_newsContext.News == null)
            {
                return NotFound();
            }
            var news = await _newsContext.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }

            _newsContext.News.Remove(news);
            await _newsContext.SaveChangesAsync();

            return Ok();
        }
    }
}
