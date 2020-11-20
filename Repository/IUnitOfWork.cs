using Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IUnitOfWork
    {
        IEmployeeRepository EmployeeRepo { get; }

        void SaveChanges();
    }
}
