//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiPrueba.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PRODUCTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCTO()
        {
            this.DETALLE_FACT = new HashSet<DETALLE_FACT>();
        }
    
        public int PK_ID_PRODUCTO { get; set; }
        public string NOMBRE_PRODUC { get; set; }
        public Nullable<int> CANTIDAD { get; set; }
        public string REFERENCIA { get; set; }
        public Nullable<double> PRECIO { get; set; }
        public Nullable<System.DateTime> FECHA { get; set; }
        public Nullable<double> IVA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_FACT> DETALLE_FACT { get; set; }
    }
}