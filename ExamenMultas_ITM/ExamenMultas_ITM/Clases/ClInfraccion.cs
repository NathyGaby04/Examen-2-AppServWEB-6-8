using ExamenMultas_ITM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace ExamenMultas_ITM.Clases
{
    public class ClInfraccion
    {
        private DBExamenEntities dBExamen = new DBExamenEntities();
        public Infraccion infraccion { get; set; }
        public string Insertar()
        {
            try
            {
                dBExamen.Infraccions.Add(infraccion);
                dBExamen.SaveChanges();
                return "Infraccion insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el Infraccion: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                Infraccion infrc = Consultar(infraccion.idFotoMulta);
                if (infrc == null)
                {
                    return "El Infraccion con el id ingresado no existe, por lo tanto no se puede actualizar";
                }
                dBExamen.Infraccions.AddOrUpdate(infraccion);
                dBExamen.SaveChanges();
                return "Se actualizó el Infraccion correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo actualizar el Infraccion: " + ex.Message;
            }
        }

        public List<Infraccion> ConsultarTodos()
        {
            return dBExamen.Infraccions
                .OrderBy(e => e.idFotoMulta)
                .ToList();
        }
        public Infraccion Consultar(int idFotoMulta)
        {
            return dBExamen.Infraccions.FirstOrDefault(e => e.idFotoMulta == idFotoMulta);
        }
        public List<Infraccion> ConsultarXPlaca(string placa)
        {
            return dBExamen.Infraccions
                .Where(e => e.PlacaVehiculo == placa)
                .OrderBy(e => e.PlacaVehiculo)
                .ToList();
        }
        public string Eliminar(int idFotoMulta)
        {
            try
            {
                Infraccion infrc = Consultar(idFotoMulta);
                if (infrc == null)
                {
                    return "El Infraccion con el id ingresado no existe, por lo tanto no se puede eliminar";
                }

                dBExamen.Infraccions.Remove(infrc);
                dBExamen.SaveChanges();
                return "Se eliminó el Infraccion correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo eliminar el Infraccion: " + ex.Message;
            }
        }

        public IQueryable ConsultarImagenesXInfraccion(string Placa)
        {
            return from I in dBExamen.Set<Infraccion>()
                   join V in dBExamen.Set<Vehiculo>()
                   on I.PlacaVehiculo equals V.Placa
                   join FI in dBExamen.Set<FotoInfraccion>()
                   on I.idFotoMulta equals FI.idInfraccion
                   where I.PlacaVehiculo == Placa
                   orderby I.FechaInfraccion
                   select new
                   {
                       idVehiculo = V.Placa,
                       TipoVehiculo = V.TipoVehiculo,
                       Marca = V.Marca,
                       Color = V.Color,
                       idInfraccion = I.idFotoMulta,
                       FechaInfraccion = I.FechaInfraccion,
                       Infraccion = I.TipoInfraccion,
                       idImagen = FI.idFoto,
                       Imagen = FI.NombreFoto
                   };
        }
    }
}