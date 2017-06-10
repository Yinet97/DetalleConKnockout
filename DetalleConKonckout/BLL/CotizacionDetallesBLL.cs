using DetalleConKonckout.DAL;
using DetalleConKonckout.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DetalleConKonckout.BLL
{
    public class CotizacionDetallesBLL
    {
        public static bool Guardar(CotizacionesDetalles detalle)
        {
            bool resultado = false;
            using (var conexion = new CotizacionDb())
            {
                try
                {
                    conexion.CotDetalle.Add(detalle);
                    conexion.SaveChanges();
                    resultado = true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return resultado;
        }
        public static CotizacionesDetalles Buscar(int? detalleCotizacionId)
        {
            CotizacionesDetalles detalle = null;
            using (var conexion = new CotizacionDb())
            {
                try
                {
                    detalle = conexion.CotDetalle.Find(detalleCotizacionId);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return detalle;
        }
        public static bool Modificar(CotizacionesDetalles detalle)
        {
            bool resultado = false;
            using (var conexion = new CotizacionDb())
            {
                try
                {
                    conexion.Entry(detalle).State = EntityState.Modified;
                    conexion.SaveChanges();
                    resultado = true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return resultado;
        }
        public static bool Eliminar(CotizacionesDetalles detalle)
        {
            bool resultado = false;
            using (var conexion = new CotizacionDb())
            {
                try
                {
                    conexion.Entry(detalle).State = EntityState.Deleted;
                    conexion.SaveChanges();
                    resultado = true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return resultado;
        }
        public static List<CotizacionesDetalles> Listar()
        {
            List<CotizacionesDetalles> listado = null;
            using (var conexion = new CotizacionDb())
            {
                try
                {
                    listado = conexion.CotDetalle.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return listado;
        }
        public static bool Save(List<CotizacionesDetalles> detalles)
        {
            bool resultado = false;
            foreach (CotizacionesDetalles detail in detalles)
            {
                resultado = Guardar(detail);
            }
            return resultado;
        }
    }
}