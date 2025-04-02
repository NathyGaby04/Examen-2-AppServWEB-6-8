using ExamenMultas_ITM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenMultas_ITM.Clases
{
    public class ClFotoInfraccion
    {
        private DBExamenEntities dBExamen = new DBExamenEntities();
        public string idInfraccion { get; set; }
        public List<string> Archivos { get; set; }
        public string GrabarImagenes()
        {
            try
            {
                if (Archivos.Count > 0)
                {
                    foreach (string Archivo in Archivos)
                    {
                        FotoInfraccion Imagen = new FotoInfraccion();
                        Imagen.idInfraccion = Convert.ToInt32(idInfraccion);
                        Imagen.NombreFoto = Archivo;
                        dBExamen.FotoInfraccions.Add(Imagen);
                        dBExamen.SaveChanges();
                    }
                    return "Imagenes guardadas correctamente";
                }
                else
                {
                    return "No se enviaron archivos para guardar";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}