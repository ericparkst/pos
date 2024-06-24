using Pos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.DataAccess.Repository.IRepository
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        void Update(Department department);
        void Save();
    }
}
