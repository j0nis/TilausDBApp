using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TilausDBApp.Models;

namespace TilausDBApp.Controllers
{
    public class TuotteetController : Controller
    {
        TilausDBEntities db = new TilausDBEntities();
        // GET: Tuotteet
        public ActionResult Index()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("login", "home");
            }
            else
            {
                ViewBag.LoggedStatus = "Kirjautunut: " + Session["UserName"];
                List<Tuotteet> model = db.Tuotteet.ToList(); //Asettaa "model" nimiseen listaan tuotteet

                db.Dispose(); //Vapauttaa olion, tärkeää muistaa, muuten muodostuu aina uusia yhteyksiä
                return View(model);
            }
        }

        public ActionResult Index2()
        {

            List<Tuotteet> model = db.Tuotteet.ToList(); //Asettaa "model" nimiseen listaan tuotteet

            db.Dispose(); //Vapauttaa olion, tärkeää muistaa, muuten muodostuu aina uusia yhteyksiä
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Tuotteet tuotteet = db.Tuotteet.Find(id);
            if (tuotteet == null) return HttpNotFound();

            ViewBag.LoggedStatus = "Kirjautunut: " + Session["UserName"];
            return View(tuotteet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TuoteID,Nimi,Ahinta,ImageLink")] Tuotteet tuotteet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tuotteet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tuotteet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("login", "home");
            }
            else
            {
                ViewBag.LoggedStatus = "Kirjautunut: " + Session["UserName"];
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TuoteID,Nimi,Ahinta,ImageLink")] Tuotteet tuotteet)
        {

            if (ModelState.IsValid)
            {
                db.Tuotteet.Add(tuotteet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tuotteet);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Tuotteet tuotteet = db.Tuotteet.Find(id);
            if (tuotteet == null) return HttpNotFound();
            ViewBag.LoggedStatus = "Kirjautunut: " + Session["UserName"];
            return View(tuotteet);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tuotteet tuotteet = db.Tuotteet.Find(id);
            db.Tuotteet.Remove(tuotteet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}