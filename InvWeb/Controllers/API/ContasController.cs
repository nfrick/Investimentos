using DataLayer;
using InvWeb.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace InvWeb.Controllers.API {
    public class ContasController : ApiController {
        private InvestimentosEntities _ctx;

        public ContasController() {
            _ctx = new InvestimentosEntities();
        }
        // GET: api/Contas
        public IEnumerable<ContaDto> Get() {
            var contas = _ctx.Contas.OrderBy(c => c.Nome).ToList();
            return contas.Select(c => new ContaDto(c)).ToList();
        }

        // GET: api/Contas/5
        public ContaDto Get(int id) {
            var conta = _ctx.Contas.Find(id);
            if (conta == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return new ContaDto(conta);
        }
    }
}
