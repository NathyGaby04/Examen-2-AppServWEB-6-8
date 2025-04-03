using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ExamenMultas_ITM.Models;
using ExamenMultas_ITM.Clases;

namespace ExamenMultas_ITM.Controllers
{
    [RoutePrefix("api/Infracciones")]
    public class InfraccionesController : ApiController
    {
        [HttpGet]
        [Route("ConsultarXPlaca")]
        public IQueryable ConsultarImagenes(string Placa)
        {
            ClInfraccion Infraccion = new ClInfraccion();
            return Infraccion.ConsultarImagenesXInfraccion(Placa);
        }
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Infraccion> ConsultarTodos()
        {
            ClInfraccion Infraccion = new ClInfraccion();
            return Infraccion.ConsultarTodos();
        }
        [HttpGet]
        [Route("Consultar")]
        public Infraccion Consultar(int CodigoInfraccion)
        {
            ClInfraccion Infraccion = new ClInfraccion();
            return Infraccion.Consultar(CodigoInfraccion);
        }
        [HttpGet]
        [Route("ConsultarVehiculoXPlaca")]
        public Vehiculo ConsultarVehiculoXPlaca(string placa)
        {
            ClVehiculo Vehiculo = new ClVehiculo();
            return Vehiculo.Consultar(placa);
        }
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Infraccion infraccion)
        {
            ClInfraccion Infraccion = new ClInfraccion();
            Infraccion.infraccion = infraccion;
            if (ConsultarVehiculoXPlaca(infraccion.PlacaVehiculo) != null ) {
                return Infraccion.Insertar();
            }
            else 
            {
                return "La placa del vehículo no se encuentra registrada.";
            }
           
        }
        [HttpPost]
        [Route("InsertarVehiculo")]
        public string InsertarVehiculo([FromBody] Vehiculo vehiculo)
        {
            ClVehiculo Vehiculo = new ClVehiculo();
            Vehiculo.vehiculo = vehiculo;
            if (ConsultarVehiculoXPlaca(vehiculo.Placa) == null)
            {
                return Vehiculo.Insertar();
            }
            else
            {
                return "El vehiculo se encuentra registrado";
            }

        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Infraccion infraccion)
        {
            ClInfraccion Infraccion = new ClInfraccion();
            Infraccion.infraccion = infraccion;
            return Infraccion.Actualizar();
        }
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int CodigoInfraccion)
        {
            ClInfraccion Infraccion = new ClInfraccion();
            return Infraccion.Eliminar(CodigoInfraccion);
        }
    }
}