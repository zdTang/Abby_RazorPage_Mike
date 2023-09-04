using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;

namespace Abby.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AbbyDbContext _db;
        public ICategoryRepository Category { get; private set; }
        public IFoodTypeRepository FoodType { get; private set; }
        public IMenuItemRepository MenuItem { get; private set; }
        public IShoppingCartRepository ShoppingCart { get; private set; }
		public IOrderHeaderRepository OrderHeader { get; private set; }
		public IOrderDetailRepository OrderDetail { get; private set; }
		public IApplicationUserRepository ApplicationUser { get; private set; }
		public UnitOfWork(AbbyDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            FoodType = new FoodTypeRepository(_db);     // instantiate an Repository
            MenuItem = new MenuItemRepository(_db);
            ShoppingCart = new ShoppingCartRepository(_db);
			OrderDetail = new OrderDetailRepository(_db);
			OrderHeader = new OrderHeaderRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
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
