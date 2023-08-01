using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;

namespace Abby.DataAccess.Repository
{
    public class FoodTypeRepository : Repository<FoodType>, IFoodTypeRepository
    {
        private readonly ApplicationDbContext _db;
        // Need to pass dbContext to Parent Class
        public FoodTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(FoodType foodType)
        {
            var objFromDb = _db.FoodType.FirstOrDefault(u => u.Id == foodType.Id);
            if (objFromDb != null)
                objFromDb.Name = foodType.Name;
        }
    }
}
