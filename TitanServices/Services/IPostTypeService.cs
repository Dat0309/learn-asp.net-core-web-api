using TitanServices.Models;

namespace TitanServices.Services
{
    public interface IPostTypeService
    {
        IEnumerable<PostType> GetAll();
        PostType GetById(string id);
        PostType Create(PostType postType);
        void Update(PostType postTyoe);
        void Delete(string id);
        IEnumerable<PostType> createsMany();
    }
}
