using DataLayer;
using InvWeb.DTOs;
using System.Linq;
using System.Web.Mvc;

namespace InvWeb.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            var db = new InvestimentosEntities();
            var contas = db.Contas.OrderBy(c => c.Nome).ToList();
            return View(contas.Select(c=>new ContaDto(c)).ToList());
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}