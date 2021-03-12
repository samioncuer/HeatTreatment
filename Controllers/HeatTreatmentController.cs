using HeatTreatment.Models;
using HeatTreatment.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeatTreatment.Controllers
{
    public class HeatTreatmentController : Controller
    {
        private DataContext _context;
        public HeatTreatmentController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
