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
        public HttpResponseMessage Get()
        {
            using (EmployeeDBContext dBContext = new EmployeeDBContext())
            {
                var Employees = dBContext.Employees.ToList();
                return Request.CreateResponse(HttpStatusCode.OK, Employees);
            }
        }
        public HttpResponseMessage Get(int id)
        {
            using (EmployeeDBContext dbContext = new EmployeeDBContext())
            {
                var entity = dbContext.Employees.FirstOrDefault(e => e.ID == id);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with ID" + id.ToString() + "not found");
                }
            }
        }
    }
}
