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
    public class CotizacionesController : ApiController
    {
        private CotizacionDb db = new CotizacionDb();

        // GET: api/Cotizaciones
        public IQueryable<Cotizaciones> GetCotizacion()
        {
            return db.Cotizacion;
        }

        // GET: api/Cotizaciones/5
        [ResponseType(typeof(Cotizaciones))]
        public IHttpActionResult GetCotizaciones(int id)
        {
            Cotizaciones cotizaciones = db.Cotizacion.Find(id);
            if (cotizaciones == null)
            {
                return NotFound();
            }

            return Ok(cotizaciones);
        }

        // PUT: api/Cotizaciones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCotizaciones(int id, Cotizaciones cotizaciones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cotizaciones.CotizacionId)
            {
                return BadRequest();
            }

            db.Entry(cotizaciones).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CotizacionesExists(id))
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

        // POST: api/Cotizaciones
        [ResponseType(typeof(Cotizaciones))]
        public IHttpActionResult PostCotizaciones(Cotizaciones cotizaciones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cotizacion.Add(cotizaciones);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cotizaciones.CotizacionId }, cotizaciones);
        }

        // DELETE: api/Cotizaciones/5
        [ResponseType(typeof(Cotizaciones))]
        public IHttpActionResult DeleteCotizaciones(int id)
        {
            Cotizaciones cotizaciones = db.Cotizacion.Find(id);
            if (cotizaciones == null)
            {
                return NotFound();
            }

            db.Cotizacion.Remove(cotizaciones);
            db.SaveChanges();

            return Ok(cotizaciones);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CotizacionesExists(int id)
        {
            return db.Cotizacion.Count(e => e.CotizacionId == id) > 0;
        }
    }
}