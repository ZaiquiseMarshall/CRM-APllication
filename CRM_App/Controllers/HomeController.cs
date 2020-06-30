using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CRM_App.Models;
using CRM_App.Services;

namespace CRM_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IAddService _service;

        public HomeController(ILogger<HomeController> logger, IAddService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var searchContacts = (List<Contact>)_service.GetContacts();
            
            if (!String.IsNullOrEmpty(searchString))
            {
                searchContacts = searchContacts.Where(s => s.Email.Contains(searchString) || s.FirstName.Contains(searchString) || s.LastName.Contains(searchString)).ToList();
            }

            ViewBag.Contacts = searchContacts;
            return View(await Task.FromResult(searchContacts.ToList()));
        }

        [HttpPost]
        public ActionResult<Contact> Index(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _service.AddContact(contact);
                return Redirect("/");
            }
            return Redirect("/AddContact");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
