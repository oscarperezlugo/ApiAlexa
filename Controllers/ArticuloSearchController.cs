using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiAlexa.Controllers
{
    public class ArticuloSearchController : ApiController
    {
        string Descripcion;        
        string Tipo;
        decimal factor;
        decimal precio;

        public IHttpActionResult BuscaArticulo(Models.Request.ArticuloSearch articulosearch)
        {
            Models.REMEXEntities9 db = new Models.REMEXEntities9();
            {
                var myArt = db.Articulos.FirstOrDefault(u => u.CodigoArticulo == articulosearch.codigo);
                Descripcion = myArt.DescripcionArticulo;                
                Tipo = myArt.TipoArticulo;
                factor = myArt.FactorConversion_;
                precio = myArt.PrecioVenta;
            }
            return Json(new { DescripcionArticulo = Descripcion, TipoArticulo = Tipo, FactorConversion_ = factor, PrecioVenta = precio });
        }
        
    }
    
}
