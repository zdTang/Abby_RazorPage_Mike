using Abby.Models;

namespace Abby.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);
        void Save();   // Save should not be in the Repository level
    }
}
