using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiAlexa.Controllers
{
    public class RemexController : ApiController
    {
        public IHttpActionResult Add(Models.Request.ProyectoDatos datos) 
        {
            using (Models.REMEXEntities8 db = new Models.REMEXEntities8())
            {
                var proyecto = new Models.CabeceraParteTrabajo();
                {
                    proyecto.CodigoEmpresa = 1;
                    proyecto.EjercicioParteTrabajo = DateTime.Now.Year;
                    proyecto.SerieParteTrabajo = " ";
                    proyecto.FechaParteTrabajo = DateTime.Now;
                    proyecto.CodigoProyecto = datos.CodigoProyecto.ToString();
                    proyecto.AnaCapitulo = datos.AnaCapitulo.ToString();
                    proyecto.AnaLote = datos.AnaLote.ToString();
                    db.CabeceraParteTrabajoes.Add(proyecto);
                    db.SaveChanges();
                }
                return Json(new {Message = "Resgistro Exitoso" });
            }
        }
        
    }
}
