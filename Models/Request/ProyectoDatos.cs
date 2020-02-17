using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiAlexa.Models.Request
{
    public class ProyectoDatos
    {
        public string CodigoProyecto { get; set; }
        public string AnaCapitulo { get; set; }
        public string AnaLote { get; set; }
    }
    public class ArticuloSearch
    {
        public string codigo { get; set; }
    }
    public class PrecioSearch
    {        
        public string CodigoArticulos { get; set; }
        public string CodigoAlmacens { get; set; }
    }
}