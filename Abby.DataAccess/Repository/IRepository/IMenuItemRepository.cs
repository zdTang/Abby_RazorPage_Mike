using Abby.Models;

namespace Abby.DataAccess.Repository.IRepository
{
    public interface IMenuItemRepository : IRepository<MenuItem>
    {
        void Update(MenuItem menuItem);
        //void Save();   // Save should not be in the Repository level
    }
}
