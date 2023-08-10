using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
namespace Abby.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AbbyDbContext _db;
        public ICategoryRepository Category { get; private set; }
        public IFoodTypeRepository FoodType { get; private set; }
        public IMenuItemRepository MenuItem { get; private set; }
        public UnitOfWork(AbbyDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            FoodType = new FoodTypeRepository(_db);     // instantiate an Repository
            MenuItem = new MenuItemRepository(_db);
        }


        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges(); ;
        }
    }
}
