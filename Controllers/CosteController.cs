using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiAlexa.Controllers
{
    public class CosteController : ApiController
    {
        decimal preciocoste;

        public IHttpActionResult BuscaArticulo(Models.Request.PrecioSearch precioSearch)
        {
            Models.REMEXEntities11 db = new Models.REMEXEntities11();
            {
                var myPrecio = db.AcumuladoStocks.FirstOrDefault(u => u.CodigoArticulo == precioSearch.CodigoArticulos && u.CodigoAlmacen == precioSearch.CodigoAlmacens && u.Ejercicio == 2019 && u.Periodo == 99 );
                
                preciocoste = myPrecio.PrecioMedio;
            }
            return Json(new { PrecioCoste = preciocoste });
        }
    }
}
