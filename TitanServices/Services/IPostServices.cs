using TitanServices.Models;

namespace TitanServices.Services
{
    public interface IPostServices
    {
        IEnumerable<PostModel> GetAll();
        PostModel GetById(string id);
        PostModel Create(PostModel post);
        void Update(PostModel post);
        void Delete(string id);
        IEnumerable<PostModel> createsMany();
    }
}
