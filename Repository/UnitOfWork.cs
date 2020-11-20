using ApplicationCore;
using Repository.Abstraction;
using Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        DatabaseContext db;
        public UnitOfWork()
        {
            db = new DatabaseContext();
        }

        private IEmployeeRepository _employeeRepo;
        public IEmployeeRepository EmployeeRepo
        {
            get
            {
                if (_employeeRepo == null)
                    _employeeRepo = new EmployeeRepository(db);
                return _employeeRepo;
            }
        }
        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
