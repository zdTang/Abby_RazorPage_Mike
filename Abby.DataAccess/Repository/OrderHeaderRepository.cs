using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;

namespace Abby.DataAccess.Repository
{
	public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
	{
		private readonly AbbyDbContext _db;

		public OrderHeaderRepository(AbbyDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(OrderHeader obj)
		{
			_db.OrderHeader.Update(obj);
		}
	}
}
