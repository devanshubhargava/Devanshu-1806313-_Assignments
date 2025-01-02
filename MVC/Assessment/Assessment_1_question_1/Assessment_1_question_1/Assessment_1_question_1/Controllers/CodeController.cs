using System.Linq;
using System.Web.Mvc;
using Assessment_1_question_1.Models; 

namespace NorthwindMVCApp.Controllers
{
    public class CodeController : Controller
    {
        
        public ActionResult GetCustomersInGermany()
        {
            using (var context = new NorthwindEntities()) 
            {
                var customersInGermany = context.Customers
                    .Where(c => c.Country == "Germany")
                    .ToList();

                return View(customersInGermany); 
            }
        }

        
        public ActionResult GetCustomerDetailsByOrderId()
        {
            using (var context = new NorthwindEntities())
            {
                var customerDetails = (from c in context.Customers
                                       join o in context.Orders on c.CustomerID equals o.CustomerID
                                       where o.OrderID == 10248
                                       select new
                                       {
                                           c.CustomerID,
                                           c.ContactName,
                                           c.CompanyName,
                                           o.OrderID,
                                           o.OrderDate,
                                           o.ShipAddress
                                       }).FirstOrDefault(); 

                if (customerDetails == null)
                {
                    return HttpNotFound(); 
                }

                return View(customerDetails); 
            }
        }
    }
}
