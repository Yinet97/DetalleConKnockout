using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DetalleConKonckout.DAL;
using DetalleConKonckout.Models;

namespace DetalleConKonckout.Controllers
{
    public class CotizacionesDetallesController : Controller
    {
        private CotizacionDb db = new CotizacionDb();

        // GET: CotizacionesDetalles
        public ActionResult Index()
        {
            return View(BLL.CotizacionDetallesBLL.Listar());
        }

        // GET: CotizacionesDetalles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CotizacionesDetalles cotizacionesDetalles = db.CotDetalle.Find(id);
            if (cotizacionesDetalles == null)
            {
                return HttpNotFound();
            }
            return View(cotizacionesDetalles);
        }

        // GET: CotizacionesDetalles/Create
        public ActionResult Create()
        {
            ViewBag.CotizacionId = new SelectList(db.Cotizacion, "CotizacionId", "Cliente");
            return View();
        }

        // POST: CotizacionesDetalles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CotizacionDetalleId,CotizacionId,ProductoId,Producto,Cantidad,SubTotal")] CotizacionesDetalles cotizacionesDetalles)
        {
            if (ModelState.IsValid)
            {
                BLL.CotizacionDetallesBLL.Guardar(cotizacionesDetalles);
                return RedirectToAction("Index");
            }

            ViewBag.CotizacionId = new SelectList(db.Cotizacion, "CotizacionId", "Cliente", cotizacionesDetalles.CotizacionId);
            return View(cotizacionesDetalles);
        }

        public JsonResult Save(List<CotizacionesDetalles> detalles)
        {
            bool resultado = BLL.CotizacionDetallesBLL.Save(detalles);

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        // GET: CotizacionesDetalles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CotizacionesDetalles cotizacionDetalles = BLL.CotizacionDetallesBLL.Buscar(id);
            if (cotizacionDetalles == null)
            {
                return HttpNotFound();
            }
            ViewBag.CotizacionId = new SelectList(db.Cotizacion, "CotizacionId", "Cliente", cotizacionDetalles.CotizacionId);
            return View(cotizacionDetalles);
        }

        // POST: CotizacionesDetalles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CotizacionDetalleId,CotizacionId,ProductoId,Producto,Cantidad,SubTotal")] CotizacionesDetalles cotizacionesDetalles)
        {
            if (ModelState.IsValid)
            {
                BLL.CotizacionDetallesBLL.Modificar(cotizacionesDetalles);
                return RedirectToAction("Index");
            }
            ViewBag.CotizacionId = new SelectList(db.Cotizacion, "CotizacionId", "Cliente", cotizacionesDetalles.CotizacionId);
            return View(cotizacionesDetalles);
        }

        // GET: CotizacionesDetalles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CotizacionesDetalles cotizacionesDetalles = db.CotDetalle.Find(id);
            if (cotizacionesDetalles == null)
            {
                return HttpNotFound();
            }
            return View(cotizacionesDetalles);
        }

        // POST: CotizacionesDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CotizacionesDetalles cotizacionesDetalles = db.CotDetalle.Find(id);
            db.CotDetalle.Remove(cotizacionesDetalles);
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
