using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;

namespace Abby.DataAccess.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly AbbyDbContext _db;
        public ShoppingCartRepository(AbbyDbContext db) : base(db)
        {
            _db = db;
        }

        public int DecrementCount(ShoppingCart shoppingCart, int count)
        {
            shoppingCart.Count -= count;
            _db.SaveChanges();
            return shoppingCart.Count;
        }

        public int IncrementCount(ShoppingCart shoppingCart, int count)
        {
            shoppingCart.Count += count;
            _db.SaveChanges();
            return shoppingCart.Count;
        }
        //public void Update(ShoppingCart shoppingCart)
        //{
        //    var objFromDb = _db.ShoppingCart.FirstOrDefault(u => u.Id == shoppingCart.Id);
        //    if (objFromDb != null)
        //    {
        //        objFromDb.ApplicationUserId = shoppingCart.ApplicationUserId;
        //        objFromDb.MenuItemId = shoppingCart.MenuItemId;
        //        objFromDb.Count = shoppingCart.Count;
        //    }
        //}
    }
}
