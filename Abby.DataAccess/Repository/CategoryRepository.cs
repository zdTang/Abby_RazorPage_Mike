using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;

namespace Abby.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly AbbyDbContext _db;
        public CategoryRepository(AbbyDbContext db) : base(db)
        {
            _db = db;
        }
        //Save should in the DbContext Level
        //public void Save()
        //{
        //    _db.SaveChanges();
        //    // _db.SaveChangesAsync();   // why not use this asynchrous method ?
        //}

        public void Update(Category category)
        {
            var objFromDb = _db.Category.FirstOrDefault(u => u.Id == category.Id);
            objFromDb.Name = category.Name;
            objFromDb.DisplayOrder = category.DisplayOrder;
        }
    }
}
