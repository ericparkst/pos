using Pos.DataAccess.Data;
using Pos.DataAccess.Repository.IRepository;
using Pos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pos.DataAccess.Repository
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        private ApplicationDbContext _db;
        public ItemRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Item obj)
        {
            _db.Items.Update(obj);
        }
    }
}
