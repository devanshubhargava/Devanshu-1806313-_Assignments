
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Assignment_1.Models;
using Assignment_1.Repositories;

namespace Assignment_1.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _repository;

        public ContactController()
        {
            
            _repository = new ContactRepository(new ContactContext()); 
        }

        
        public async Task<ActionResult> Index()
        {
            var contacts = await _repository.GetAllAsync();
            return View(contacts);
        }

        
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<ActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                await _repository.CreateAsync(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        
        public async Task<ActionResult> Delete(long id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
