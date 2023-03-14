using TitanServices.DTO;
using TitanServices.Helper;
using TitanServices.Models;

namespace TitanServices.Services
{
    public class ContentServices : IContentServices
    {

        private readonly ContentContext _context;
        public ContentServices(ContentContext context)
        {
            _context = context;
        }
        public ContentModel Create(ContentModel content)
        {
            _context.Contents.Add(content);
            _context.SaveChanges();
            return content;
        }

        public void Delete(string id)
        {
            var content = _context.Contents.Find(id);
            if (content != null)
            {
                _context.Contents.Remove(content);
                _context.SaveChanges();
            }
        }

        public IEnumerable<ContentModel> GetAll()
        {
            if (_context.Contents == null) return Enumerable.Empty<ContentModel>();
            return _context.Contents;
        }

        public ContentModel GetById(string id)
        {
            return _context.Contents.Find(id);
        }

        public void Update(ContentModel contentParam)
        {
            var content = _context.Contents.Find(contentParam._id);
            if (content != null)
                throw new AppException("Content not found");

            content = contentParam;
            _context.Contents.Update(content);
            _context.SaveChanges();
        }
    }
}
