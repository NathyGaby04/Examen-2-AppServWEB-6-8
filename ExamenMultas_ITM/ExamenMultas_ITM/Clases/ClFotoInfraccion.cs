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
        public FotoInfraccion Consultar(int idFoto)
        {
            return dBExamen.FotoInfraccions.FirstOrDefault(e => e.idFoto == idFoto);
        }
        public string Eliminar(int idFoto)
        {
            try
            {
                FotoInfraccion fotoinfrc = Consultar(idFoto);
                if (fotoinfrc == null)
                {
                    return "El Infraccion con el id ingresado no existe, por lo tanto no se puede eliminar";
                }

                dBExamen.FotoInfraccions.Remove(fotoinfrc);
                dBExamen.SaveChanges();


                return "Se eliminó la foto de la Infraccion correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo eliminar la Foto de la Infraccion: " + ex.Message;
            }
        }
    }
}