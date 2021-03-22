using HeatTreatment.Models;
using HeatTreatment.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace HeatTreatment.Controllers
{
    public class HeatTreatmentController : Controller
    {
        private DataContext _context;
        public HeatTreatmentController(DataContext context)
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
