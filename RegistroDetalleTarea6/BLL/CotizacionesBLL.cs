﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RegistroDetalleTarea6.DAL;
using RegistroDetalleTarea6.Entidades;

namespace RegistroDetalleTarea6.BLL
{
    public class CotizacionesBLL
    {
        public static bool Guardar(Cotizaciones cotizacion)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Cotizaciones.Add(cotizacion) != null)
                {
                    foreach (var item in cotizacion.Detalle)
                    {
                        contexto.Articulos.Find(item.ArticuloId).CantidadCotizada -= item.Cantidad;
                    }
                
                    contexto.SaveChanges();
                    paso = true;
                }

                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Modificar(Cotizaciones cotizacion)
        {

            bool paso = false;

            Contexto contexto = new Contexto();

            try
            {
              
                //recorrer el detalle
                foreach (var item in cotizacion.Detalle)
                {
                   
                    var estado = item.Id > 0 ? EntityState.Modified : EntityState.Added;
                    contexto.Entry(item).State = estado;
                }

                //Idicar que se esta modificando el encabezado
                contexto.Entry(cotizacion).State = EntityState.Modified;

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;

        }

        public static bool Eliminar(int id)
        {

            bool paso = false;

            Contexto contexto = new Contexto();

            try
            {

                Cotizaciones cotizacion = contexto.Cotizaciones.Find(id);

                foreach(var item in cotizacion.Detalle)
                {
                    var cuidad = contexto.Articulos.Find(item.ArticuloId);
                    cuidad.CantidadCotizada += item.Cantidad;
                }

                contexto.Cotizaciones.Remove(cotizacion);
                if (contexto.SaveChanges() > 0)

                {
                    paso = true;
                }

                contexto.Dispose();
            }

            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public static Cotizaciones Buscar(int id)
        {

            Cotizaciones cotizacion = new Cotizaciones();
            Contexto contexto = new Contexto();
            try
            {
                cotizacion = contexto.Cotizaciones.Find(id);            
                cotizacion.Detalle.Count();

                //Cargar los nombres de las personas y articulos
                foreach (var item in cotizacion.Detalle)
                {
                    //forzando la persona y el articulo a cargarse
                    string s = item.Articulos.Descripcion;
                    string r = item.Personas.Nombres;
                }
                contexto.Dispose();
            }

            catch (Exception)
            {
                throw;
            }

            return cotizacion;
        }

        public static List<Cotizaciones> GetList(Expression<Func<Cotizaciones, bool>> expression)
        {

            List<Cotizaciones> Cotizaciones = new List<Cotizaciones>();
            Contexto contexto = new Contexto();

            try
            {
                Cotizaciones = contexto.Cotizaciones.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return Cotizaciones;
        }
    }
}
