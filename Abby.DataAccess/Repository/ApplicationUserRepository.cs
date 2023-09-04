using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;

namespace Abby.DataAccess.Repository
{
	public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
	{
		private readonly AbbyDbContext _db;

		public ApplicationUserRepository(AbbyDbContext db) : base(db)
		{
			_db = db;
		}
	}
}
