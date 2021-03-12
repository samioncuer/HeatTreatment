using HeatTreatment.Models;
using HeatTreatment.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeatTreatment.Controllers
{
    public class OkuyucuController : Controller
    {
        private DataContext _context;
        public OkuyucuController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetOkuyucu()
        {
            return Json(_context.GRFOKUYUCU.ToList());
        } 
        public void UpdateOkuyucu(string model){
            tempOkuyucu okuyucu = new tempOkuyucu();
            okuyucu = Newtonsoft.Json.JsonConvert.DeserializeObject<tempOkuyucu>(model);
            Console.WriteLine(okuyucu.ID);
            Console.WriteLine(okuyucu.GRUP);
            Console.WriteLine(okuyucu.ARTI);
            Console.WriteLine(okuyucu.EKSI);
            try
            {
                if(okuyucu.ID == 0){
                    Okuyucu _okuyucu = new Okuyucu();
                    _okuyucu.GRUP = okuyucu.GRUP;
                    _okuyucu.OKUYUCUADI = okuyucu.OKUYUCUADI;
                    _okuyucu.ARTI = okuyucu.ARTI;
                    _okuyucu.EKSI = okuyucu.EKSI;
                    _context.GRFOKUYUCU.Add(_okuyucu);
                    _context.SaveChanges();
                }
                else{
                    Okuyucu _okuyucu = _context.GRFOKUYUCU.FirstOrDefault(w=> w.ID == okuyucu.ID);
                    _okuyucu.GRUP = okuyucu.GRUP;
                    _okuyucu.OKUYUCUADI = okuyucu.OKUYUCUADI;
                    _okuyucu.ARTI = okuyucu.ARTI;
                    _okuyucu.EKSI = okuyucu.EKSI;
                    //_context.GRFOKUYUCU.Add(_okuyucu);
                    _context.SaveChanges();
                }
            }
            catch (System.Exception ex)
            {
                var ss = ex.Message;
            }
        }
        [HttpPost]
        public void DeleteOkuyucu(int id)
        {
            try
            {
            Okuyucu _okuyucu = _context.GRFOKUYUCU.FirstOrDefault( w => w.ID == id);
            _context.GRFOKUYUCU.Remove(_okuyucu);
            _context.SaveChanges();
            }
            catch (System.Exception ex)
            {
                var ss = ex.Message;
            }
        }
        public class tempOkuyucu
        {
            public int ID {get; set;}
            public string GRUP {get; set;}
            public string OKUYUCUADI {get; set;}
            public double ARTI {get; set;}
            public double EKSI {get; set;}
        }
    }
}