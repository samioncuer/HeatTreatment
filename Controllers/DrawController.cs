using HeatTreatment.Models;
using HeatTreatment.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Draw.Controllers
{
    public class DrawController : Controller
    {
        private DataContext _context;
        public DrawController(DataContext context)
        {
            _context = context;
        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}
