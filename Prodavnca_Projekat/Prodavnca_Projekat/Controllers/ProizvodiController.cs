using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Prodavnca_Projekat.Models;

namespace Prodavnca_Projekat.Controllers
{
    public class ProizvodiController : Controller
    {
        // GET: Proizvodi
        public ActionResult Index()
        {
            return View();
        }
        // DATABASE Context
        private ProdavnicaContext dbcontext;
        public ProizvodiController()
        {
            dbcontext = new ProdavnicaContext();
        }

        // GET za tabelu Proizvodi
        public JsonResult GetProizvodi (string sord, int page, int rows, string searchString)
        {
            sord = (sord == null) ? "" : sord;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var ProizvodiList = dbcontext.Proizvodi.Select(
                p => new
                {
                    p.ProizvodID,
                    p.Naziv,
                    p.Opis,
                    p.Kategorija,
                    p.Proizvodjac,
                    p.Dobavljac,
                    p.Cena

                });
            int totalRecords = ProizvodiList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sord.ToUpper() == "DESC")
            {
                ProizvodiList = ProizvodiList.OrderByDescending(p => p.ProizvodID);
                ProizvodiList = ProizvodiList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                ProizvodiList = ProizvodiList.OrderBy(p => p.ProizvodID);
                ProizvodiList = ProizvodiList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            //Search za Proizvode
            if (!string.IsNullOrEmpty(searchString))
            {
                ProizvodiList = ProizvodiList.Where(p => p.Naziv.Contains(searchString) || p.Kategorija.Contains(searchString) || p.Proizvodjac.Contains(searchString) || p.Dobavljac.Contains(searchString));
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = ProizvodiList
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        // CREATE metoda za Proizvode
        [HttpPost]
        public JsonResult Create([Bind(Exclude = "Id")] Proizvodi proizvodi)
        {
            StringBuilder msg = new StringBuilder();
            try
            {
                if(ModelState.IsValid)
                {
                    dbcontext.Proizvodi.Add(proizvodi);
                    dbcontext.SaveChanges();
                    return Json("Sacuvano Uspesno", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var errorList = (from item in ModelState
                                     where item.Value.Errors.Any()
                                     select item.Value.Errors[0].ErrorMessage).ToList();
                    return Json(errorList, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                var errormessage = "Greska: " + ex.Message;
                return Json(errormessage, JsonRequestBehavior.AllowGet);
            }
        }

        // EDIT metoda za Proizvode
        public JsonResult Edit([Bind(Exclude = "Id")] Proizvodi proizvodi)
        {
            StringBuilder msg = new StringBuilder();
            try
            {
                if(ModelState.IsValid)
                {
                    dbcontext.Entry(proizvodi).State = EntityState.Modified;
                    dbcontext.SaveChanges();
                    return Json("Sacuvano Uspesno", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var errorList = (from item in ModelState
                                     where item.Value.Errors.Any()
                                     select item.Value.Errors[0].ErrorMessage).ToList();
                    return Json(errorList, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                var errormessage = "Greska: " + ex.Message;
                return Json(errormessage, JsonRequestBehavior.AllowGet);
            }
        }

        // DELETE metoda za Proizvode
        public string Delete(int Id)
        {
            Proizvodi proizvodi = dbcontext.Proizvodi.Find(Id);
            dbcontext.Proizvodi.Remove(proizvodi);
            dbcontext.SaveChanges();
            return "Uspesno izbrisano";
        }
    }
}