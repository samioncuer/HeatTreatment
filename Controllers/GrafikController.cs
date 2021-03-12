using HeatTreatment.Models;
using HeatTreatment.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
//using AutoMapper;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using System.Net;
using Newtonsoft.Json;

namespace HeatTreatment.Controllers
{
    public class GrafikController : Controller
    {
        private DataContext _context;
        public GrafikController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetGrafik()
        {
            return Json(_context.GRAFIKLER.ToList());
        }
        [HttpPost]
        public void UpdateGrafik(string model,string timespan)
        {
           
            tempGrafik grafik = new tempGrafik();
            //Newtonsoft.Json.JsonConvert.PopulateObject(model, grafik);
            grafik = Newtonsoft.Json.JsonConvert.DeserializeObject<tempGrafik>(model); 
            try
            {
                int _hour = Convert.ToInt32(timespan.Split(":")[0]);
                int _min = Convert.ToInt32(timespan.Split(":")[1]);
                TimeSpan gulu = new TimeSpan(_hour,_min,0);
                grafik.ZAMANARALIK = gulu;
                if(grafik.ID == 0){
                    Grafik _grafik = new Grafik();
                    _grafik.GRAFIKADI = grafik.GRAFIKADI;
                    _grafik.ZAMANARALIK = grafik.ZAMANARALIK.Value;
                    _grafik.BASLAMA = grafik.BASLAMA.Value;
                    _context.GRAFIKLER.Add(_grafik);
                    _context.SaveChanges();
                }
                else{
                    //Grafik _grafik = new Grafik();
                    Grafik _grafik = _context.GRAFIKLER.FirstOrDefault( w => w.ID == grafik.ID);
                    _grafik.GRAFIKADI = grafik.GRAFIKADI;
                    _grafik.ZAMANARALIK = grafik.ZAMANARALIK.Value;
                    _grafik.BASLAMA = grafik.BASLAMA.Value;
                    //_context.GRAFIKLER.Add(_grafik);
                    _context.SaveChanges();
                }
                //Grafik _grafik = new Grafik();
                //_grafik.ID = grafik.ID;
                //_grafik.ZAMANARALIK = grafik.ZAMANARALIK.Value;
            }
            catch (System.Exception ex)
            {
                var ss = ex.Message;
            }
        }

        [HttpPost]
        public void DeleteGrafik(int id)
        {
            try
            {
            Grafik _grafik = _context.GRAFIKLER.FirstOrDefault( w => w.ID == id);
            _context.GRAFIKLER.Remove(_grafik);
            _context.SaveChanges();
            }
            catch (System.Exception ex)
            {
                var ss = ex.Message;
            }
        }
        public class tempGrafik
        {
            public int ID { get; set; }
            public string GRAFIKADI { get; set; }
            public TimeSpan? ZAMANARALIK { get; set; }
            public DateTime? BASLAMA { get; set; }
        }
    }
}
