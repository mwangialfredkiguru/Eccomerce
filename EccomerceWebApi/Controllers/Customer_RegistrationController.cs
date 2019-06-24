using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EccomerceWebApi.Controllers
{
    public class Customer_RegistrationController : ApiController
    {
        private MaliMaliDbEntities Db = new MaliMaliDbEntities();
        [HttpGet]
        public IEnumerable<Customer_Reg_Table> GetCustomers()
        {
            return Db.Customer_Reg_Table.ToList();
        }
        [HttpPost]
        public HttpResponseMessage register_Customer([FromBody] Customer_Reg_Table Reg_customer)
        {
            try
            {
                Db.Customer_Reg_Table.Add(Reg_customer);
                Db.SaveChanges();
                var message = Request.CreateResponse(HttpStatusCode.Created, Reg_customer);
                return message;
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }
    }
}
