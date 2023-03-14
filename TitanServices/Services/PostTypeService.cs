using TitanServices.DTO;
using TitanServices.Helper;
using TitanServices.Models;

namespace TitanServices.Services
{
    public class PostTypeService : IPostTypeService
    {

        private readonly PostTupeContext _context;

        public PostTypeService(PostTupeContext context)
        {
            _context = context;
        }

        public PostType Create(PostType postType)
        {
            if (_context.PostTypes.Any(x => x.Title == postType.Title))
                throw new AppException("Title type \"" + postType.Title + "\" is already exists");
            _context.PostTypes.Add(postType);
            _context.SaveChanges();
            return postType;
        }

        public IEnumerable<PostType> createsMany()
        {
            var postTypes = new PostType[]
            {
                new PostType{Title="NEWS & EVENTS"},
                new PostType{Title="BLOGS"},
            };
            foreach (var postType in postTypes)
            {
                _context.PostTypes.Add(postType);
            }
            _context.SaveChanges();
            return postTypes;
        }

        public void Delete(string id)
        {
            var postType = _context.PostTypes.Find(id);
            if (postType != null)
            {
                _context.PostTypes.Remove(postType);
                _context.SaveChanges();
            }
        }

        public IEnumerable<PostType> GetAll()
        {
            if (_context.PostTypes == null) return Enumerable.Empty<PostType>();
            return _context.PostTypes;
        }

        public PostType GetById(string id)
        {
            return _context.PostTypes.Find(id);
        }

        public void Update(PostType postTyoeParam)
        {
            var postType = _context.PostTypes.Find(postTyoeParam._id);
            if (postType != null)
            {
                throw new AppException("PostType not found");
            }

            postType = postTyoeParam;
            _context.PostTypes.Update(postType);
            _context.SaveChanges();
        }
    }
}
