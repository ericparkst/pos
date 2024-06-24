using Pos.DataAccess.Data;
using Pos.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }
        public IDepartmentRepository Department { get; private set; }
        public IItemRepository Item { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Department = new DepartmentRepository(_db);
            Item = new ItemRepository(_db);
        }   

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
