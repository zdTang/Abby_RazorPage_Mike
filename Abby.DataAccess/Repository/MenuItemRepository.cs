using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;

namespace Abby.DataAccess.Repository
{
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
    {
        private readonly ApplicationDbContext _db;
        // Need to pass dbContext to Parent Class
        public MenuItemRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(MenuItem menuItem)
        {
            var objFromDb = _db.MenuItem.FirstOrDefault(u => u.Id == menuItem.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = menuItem.Name;
                objFromDb.Description = menuItem.Description;
                objFromDb.Price = menuItem.Price;
                objFromDb.CategoryId = menuItem.CategoryId;
                objFromDb.FoodTypeId = menuItem.FoodTypeId;
                if (objFromDb.Image != null) // if the database has image value, then update it or not   ????      don't understand                             
                {
                    objFromDb.Image = menuItem.Image;
                }
            }
        }
    }
}
