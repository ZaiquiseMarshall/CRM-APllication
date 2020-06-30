using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace CRM_App.Controllers
{
    public class AddContactController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
