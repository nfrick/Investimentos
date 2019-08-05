using DataLayer;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using InvWeb.DTOs;

namespace InvWeb.Controllers {
    public class ContasController : Controller {
        private readonly InvestimentosEntities _db = new InvestimentosEntities();

        // GET: Contas
        public ActionResult Index() {
            var contas = _db.Contas.OrderBy(c => c.Nome).ToList();
            return View(contas.Select(c => new ContaDto(c)).ToList());
        }

        // GET: Contas/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var conta = _db.Contas.Find(id);
            if (conta == null) {
                return HttpNotFound();
            }
            return View(new ContaDto(conta));
        }

        // GET: Contas/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Contas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContaId,Nome,Agencia,ContaCorrente,Operacao,Senha,Info")] Conta conta) {
            if (!ModelState.IsValid) return View(conta);
            _db.Contas.Add(conta);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Contas/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var conta = _db.Contas.Find(id);
            if (conta == null) {
                return HttpNotFound();
            }
            return View(conta);
        }

        // POST: Contas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContaId,Nome,Banco,Agencia,ContaCorrente,Operacao,Senha,Info")] Conta conta) {
            if (!ModelState.IsValid) return View(conta);
            _db.Entry(conta).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Contas/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var conta = _db.Contas.Find(id);
            if (conta == null) {
                return HttpNotFound();
            }
            if (conta.AtivosDaConta.Any() || conta.Fundos.Any() || conta.LCAs.Any()) {
                return HttpNotFound();
            }
            return View(conta);
        }

        // POST: Contas/Delete/5
        [System.Web.Mvc.HttpPost, System.Web.Mvc.ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            var conta = _db.Contas.Find(id);
            _db.Contas.Remove(conta);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
