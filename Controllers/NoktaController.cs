using HeatTreatment.Models;
using HeatTreatment.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeatTreatment.Controllers
{
    public class NoktaController : Controller
    {
        private DataContext _context;
        public NoktaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetNokta()
        {
            return Json(_context.GRFNOKTALAR.ToList());
        }   
        [HttpPost]
        public JsonResult GetNoktaById(int grafikId)
        {
            return Json(_context.GRFNOKTALAR.Where(w => w.GRAFIKID == grafikId).ToList());
        }   
        [HttpPost]
        public void UpdateNokta(string model,string timespan)
        {
           
            tempNokta nokta = new tempNokta();
            //Newtonsoft.Json.JsonConvert.PopulateObject(model, grafik);
            nokta = Newtonsoft.Json.JsonConvert.DeserializeObject<tempNokta>(model); 
            try
            {
                int _hour = Convert.ToInt32(timespan.Split(":")[0]);
                int _min = Convert.ToInt32(timespan.Split(":")[1]);
                TimeSpan gulu = new TimeSpan(_hour,_min,0);
                nokta.BEKLEMESURESI = gulu;
                if(nokta.ID == 0){
                    Nokta _nokta = new Nokta();
                    _nokta.GRAFIKID = nokta.GRAFIKID;
                    _nokta.BASLAMASICAKLIK = nokta.BASLAMASICAKLIK;
                    _nokta.BITISSICAKLIK = nokta.BITISSICAKLIK;
                    _nokta.BEKLEMESURESI = nokta.BEKLEMESURESI.Value;
                    _nokta.SIRANO = nokta.SIRANO;
                    _nokta.HIZI = nokta.HIZI;
                    _nokta.ARTI = nokta.ARTI;
                    _nokta.EKSI = nokta.EKSI;
                    _context.GRFNOKTALAR.Add(_nokta);
                    _context.SaveChanges();
                }
                else{
                    //Grafik _grafik = new Grafik();
                    Nokta _nokta = _context.GRFNOKTALAR.FirstOrDefault( w => w.ID == nokta.ID);
                    _nokta.GRAFIKID = nokta.GRAFIKID;
                    _nokta.BASLAMASICAKLIK = nokta.BASLAMASICAKLIK;
                    _nokta.BITISSICAKLIK = nokta.BITISSICAKLIK;
                    _nokta.BEKLEMESURESI = nokta.BEKLEMESURESI.Value;
                    _nokta.SIRANO = nokta.SIRANO;
                    _nokta.HIZI = nokta.HIZI;
                    _nokta.ARTI = nokta.ARTI;
                    _nokta.EKSI = nokta.EKSI;
                    _context.SaveChanges();
                }
            }
            catch (System.Exception ex)
            {
                var ss = ex.Message;
            }
        }
        [HttpPost]
        public void DeleteNokta(int id)
        {
            try
            {
            Nokta _nokta = _context.GRFNOKTALAR.FirstOrDefault( w => w.ID == id);
            _context.GRFNOKTALAR.Remove(_nokta);
            _context.SaveChanges();
            }
            catch (System.Exception ex)
            {
                var ss = ex.Message;
            }
        }
        public class tempNokta{
            public int ID {get; set;}
            public int GRAFIKID {get; set;}
            public double BASLAMASICAKLIK {get; set;}
            public double BITISSICAKLIK {get; set;}
            public TimeSpan? BEKLEMESURESI {get; set;}
            public double HIZI {get; set;}
            public int SIRANO {get; set;}
            public double ARTI {get; set;}
            public double EKSI {get; set;} 
        }
    }
}