using DetalleConKonckout.DAL;
using DetalleConKonckout.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DetalleConKonckout.BLL
{
    public class CotizacionesBLL
    {
        public static bool Guardar(Cotizaciones cotizacion)
        {
            bool resultado = false;
            using (var conexion = new CotizacionDb())
            {
                try
                {
                    conexion.Cotizacion.Add(cotizacion);
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
        public static Cotizaciones Buscar(int? cotizacionId)
        {
            Cotizaciones cotizacion = null;
            using (var conexion = new CotizacionDb())
            {
                try
                {
                    cotizacion = conexion.Cotizacion.Find(cotizacionId);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return cotizacion;
        }
        public static bool Modificar(Cotizaciones cotizacion)
        {
            bool resultado = false;
            using (var conexion = new CotizacionDb())
            {
                try
                {
                    conexion.Entry(cotizacion).State = EntityState.Modified;
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
        public static bool Eliminar(Cotizaciones cotizacion)
        {
            bool resultado = false;
            using (var conexion = new CotizacionDb())
            {
                try
                {
                    conexion.Entry(cotizacion).State = EntityState.Deleted;
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
        public static List<Cotizaciones> Listar()
        {
            List<Cotizaciones> listado = null;
            using (var conexion = new CotizacionDb())
            {
                try
                {
                    listado = conexion.Cotizacion.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return listado;
        }
    }
}