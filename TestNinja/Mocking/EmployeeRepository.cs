using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking.Interfaces;

namespace TestNinja.Mocking
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EmployeeContext _db;

        public EmployeeRepository()
        {
            _db = new EmployeeContext();
        }

        public void DeleteEmployeeById(int id)
        {
            var employee = _db.Employees.Find(id);
            if (employee == null) return;

            _db.Employees.Remove(employee);
            _db.SaveChanges();
        }
    }
}
