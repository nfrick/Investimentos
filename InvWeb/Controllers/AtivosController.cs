using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace InvWeb.Controllers
{
    public class AtivosController : Controller
    {
        private InvestimentosEntities db = new InvestimentosEntities();

        // GET: Ativos
        public ActionResult Index()
        {
            return View(db.Ativos.ToList());
        }

        // GET: Ativos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ativo ativo = db.Ativos.Find(id);
            if (ativo == null)
            {
                return HttpNotFound();
            }
            return View(ativo);
        }

        // GET: Ativos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ativos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo,Nome")] Ativo ativo)
        {
            if (ModelState.IsValid)
            {
                db.Ativos.Add(ativo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ativo);
        }

        // GET: Ativos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ativo ativo = db.Ativos.Find(id);
            if (ativo == null)
            {
                return HttpNotFound();
            }
            return View(ativo);
        }

        // POST: Ativos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo,Nome")] Ativo ativo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ativo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ativo);
        }

        // GET: Ativos/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ativo ativo = db.Ativos.Find(id);
            if (ativo == null)
            {
                return HttpNotFound();
            }
            return View(ativo);
        }

        // POST: Ativos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Ativo ativo = db.Ativos.Find(id);
            db.Ativos.Remove(ativo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
