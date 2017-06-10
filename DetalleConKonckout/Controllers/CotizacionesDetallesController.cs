using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DetalleConKonckout.DAL;
using DetalleConKonckout.Models;

namespace DetalleConKonckout.Controllers
{
    public class CotizacionesDetallesController : ApiController
    {
        private CotizacionDb db = new CotizacionDb();

        // GET: api/CotizacionesDetalles
        public IQueryable<CotizacionesDetalles> GetCotDetalle()
        {
            return db.CotDetalle;
        }

        // GET: api/CotizacionesDetalles/5
        [ResponseType(typeof(CotizacionesDetalles))]
        public IHttpActionResult GetCotizacionesDetalles(int id)
        {
            CotizacionesDetalles cotizacionesDetalles = db.CotDetalle.Find(id);
            if (cotizacionesDetalles == null)
            {
                return NotFound();
            }

            return Ok(cotizacionesDetalles);
        }

        // PUT: api/CotizacionesDetalles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCotizacionesDetalles(int id, CotizacionesDetalles cotizacionesDetalles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cotizacionesDetalles.CotizacionDetalleId)
            {
                return BadRequest();
            }

            db.Entry(cotizacionesDetalles).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CotizacionesDetallesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CotizacionesDetalles
        [ResponseType(typeof(CotizacionesDetalles))]
        public IHttpActionResult PostCotizacionesDetalles(CotizacionesDetalles cotizacionesDetalles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CotDetalle.Add(cotizacionesDetalles);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cotizacionesDetalles.CotizacionDetalleId }, cotizacionesDetalles);
        }

        // DELETE: api/CotizacionesDetalles/5
        [ResponseType(typeof(CotizacionesDetalles))]
        public IHttpActionResult DeleteCotizacionesDetalles(int id)
        {
            CotizacionesDetalles cotizacionesDetalles = db.CotDetalle.Find(id);
            if (cotizacionesDetalles == null)
            {
                return NotFound();
            }

            db.CotDetalle.Remove(cotizacionesDetalles);
            db.SaveChanges();

            return Ok(cotizacionesDetalles);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CotizacionesDetallesExists(int id)
        {
            return db.CotDetalle.Count(e => e.CotizacionDetalleId == id) > 0;
        }
    }
}