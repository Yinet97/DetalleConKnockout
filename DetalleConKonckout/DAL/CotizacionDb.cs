using DetalleConKonckout.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DetalleConKonckout.DAL
{
    public class CotizacionDb : DbContext
    {
        public CotizacionDb() : base("ConStr")
        {
            
        }

        public DbSet<Cotizaciones> Cotizacion { get; set; }
        public DbSet<CotizacionesDetalles> CotDetalle { get; set; }
    }
}