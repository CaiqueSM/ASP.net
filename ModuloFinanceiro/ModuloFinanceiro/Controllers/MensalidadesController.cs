using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ModuloFinanceiro.Models;
using System;

namespace ModuloFinanceiro.Controllers
{
    public class MensalidadesController : Controller
    {
        private ModuloFinanceiroContext db = new ModuloFinanceiroContext();
       
        public float CalcularMensalidade(Mensalidades mensalidades)
        {
            //Se o pagamento da mensalidade está atrasado cobra-se um percentual de juros por dia corrido.
            if (DateTime.Compare(mensalidades.DataDePagamento, mensalidades.DataDeVencimento) > 0)
            {
                return mensalidades.ValorDoCurso + (mensalidades.ValorDoCurso * ((mensalidades.Juros / 100) *
                    (mensalidades.DataDePagamento.Subtract(mensalidades.DataDeVencimento).Days)));
            }
            else
            {
                //Se o pagamento foi realizado dentro do prazo é forneciido um desconto na mensalidade.
                return mensalidades.ValorDoCurso - ((mensalidades.Bolsa / 100) * mensalidades.ValorDoCurso);
            }
        }
        
        
        // GET: Mensalidades
        public ActionResult Index()
        {
            return View(db.Mensalidades.ToList());
        }

        // GET: Mensalidades/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mensalidades mensalidades = db.Mensalidades.Find(id);
            if (mensalidades == null)
            {
                return HttpNotFound();
            }
            return View(mensalidades);
        }

        // GET: Mensalidades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mensalidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Curso,Tipo,ValorDoCurso,Juros,Bolsa,Mensalidade,DataDePagamento,DataDeVencimento")] Mensalidades mensalidades)
        {
            if (ModelState.IsValid)
            {
                mensalidades.Mensalidade = CalcularMensalidade(mensalidades);
                db.Mensalidades.Add(mensalidades);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mensalidades);
        }

        // GET: Mensalidades/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mensalidades mensalidades = db.Mensalidades.Find(id);
            if (mensalidades == null)
            {
                return HttpNotFound();
            }
            return View(mensalidades);
        }

        // POST: Mensalidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Curso,Tipo,ValorDoCurso,Juros,Bolsa,Mensalidade,DataDePagamento,DataDeVencimento")] Mensalidades mensalidades)
        {
            if (ModelState.IsValid)
            {
                mensalidades.Mensalidade = CalcularMensalidade(mensalidades);
                db.Entry(mensalidades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mensalidades);
        }

        // GET: Mensalidades/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mensalidades mensalidades = db.Mensalidades.Find(id);
            if (mensalidades == null)
            {
                return HttpNotFound();
            }
            return View(mensalidades);
        }

        // POST: Mensalidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Mensalidades mensalidades = db.Mensalidades.Find(id);
            db.Mensalidades.Remove(mensalidades);
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
