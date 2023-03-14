using TitanServices.Models;

namespace TitanServices.Services
{
    public interface IContentServices
    {
        IEnumerable<ContentModel> GetAll();
        ContentModel GetById(string id);
        ContentModel Create(ContentModel content);
        void Update(ContentModel content);
        void Delete(string id);
    }
}
