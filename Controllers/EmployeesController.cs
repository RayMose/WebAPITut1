using WebAPITut1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPITut1.Controllers
{
    public class EmployeesController : ApiController
    {
        public IEnumerable<Employee> Get()
        {
            using (EmployeeDBContext dBContext = new EmployeeDBContext())
            {
                return dBContext.Employees.ToList();
            }
        }
        public Employee Get(int id)
        {
            using (EmployeeDBContext dbContext = new EmployeeDBContext())
            {
                return dbContext.Employees.FirstOrDefault(e => e.ID == id);
            }
        }
    }
}
