//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiAlexa.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CabeceraParteTrabajo
    {
        public int NumeroParteTrabajo { get; set; }
        public short CodigoEmpresa { get; set; }
        public int EjercicioParteTrabajo { get; set; }
        public string SerieParteTrabajo { get; set; }
        public Nullable<System.DateTime> FechaParteTrabajo { get; set; }
        public string CodigoProyecto { get; set; }
        public string AnaCapitulo { get; set; }
        public string AnaLote { get; set; }
        public byte[] CodigoEmpleadoLc { get; set; }
        public Nullable<int> StatusAnalitica { get; set; }
        public string Comentarios { get; set; }
        public Nullable<int> IdTareaLc { get; set; }
        public string NombreTareaLc { get; set; }
        public Nullable<int> MovAnalitica { get; set; }
    }
}
