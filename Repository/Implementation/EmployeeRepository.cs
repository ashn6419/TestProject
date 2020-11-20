using ApplicationCore;
using DomainModels.Entities;
using Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        DatabaseContext context
        {
            get
            {
                return db as DatabaseContext;
            }
        }
        public EmployeeRepository(DbContext _db) : base(_db)
        {

        }
    }
}
