using ExamenMultas_ITM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace ExamenMultas_ITM.Clases
{
    public class ClVehiculo
    {
        private DBExamenEntities dBExamen = new DBExamenEntities();
        public Vehiculo vehiculo { get; set; }
        public string Insertar()
        {
            try
            {
                dBExamen.Vehiculoes.Add(vehiculo);
                dBExamen.SaveChanges();
                return "Vehiculo insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el vehiculo: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                Vehiculo vhl = Consultar(vehiculo.Placa);
                if (vhl == null)
                {
                    return "El vehiculo con el id ingresado no existe, por lo tanto no se puede actualizar";
                }
                dBExamen.Vehiculoes.AddOrUpdate(vehiculo);
                dBExamen.SaveChanges();
                return "Se actualizó el vehiculo correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo actualizar el vehiculo: " + ex.Message;
            }
        }

        public List<Vehiculo> ConsultarTodos()
        {
            return dBExamen.Vehiculoes
                .OrderBy(e => e.Placa)
                .ToList();
        }
        public Vehiculo Consultar(string placa)
        {
            return dBExamen.Vehiculoes.FirstOrDefault(e => e.Placa == placa);
        }
        public List<Vehiculo> ConsultarMarca(string marca)
        {
            return dBExamen.Vehiculoes
                .Where(e => e.Marca == marca)
                .OrderBy(e => e.Placa)
                .ToList();
        }
        public string Eliminar(string placa)
        {
            try
            {
                Vehiculo vhl = Consultar(placa);
                if (vhl == null)
                {
                    return "El vehiculo con el id ingresado no existe, por lo tanto no se puede eliminar";
                }

                dBExamen.Vehiculoes.Remove(vhl);
                dBExamen.SaveChanges();
                return "Se eliminó el vehiculo correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo eliminar el vehiculo: " + ex.Message;
            }
        }

    }
}