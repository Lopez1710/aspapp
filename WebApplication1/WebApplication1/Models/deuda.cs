//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class deuda
    {
        public int id { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<decimal> deuda1 { get; set; }
        public Nullable<int> Cliente_Id_Fk { get; set; }
        public Nullable<int> Articulo_id_Fk { get; set; }
        public Nullable<int> Cantidad { get; set; }
    
        public virtual articulos articulos { get; set; }
        public virtual clientes clientes { get; set; }
    }
}
