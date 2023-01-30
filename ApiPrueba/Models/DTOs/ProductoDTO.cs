using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiPrueba.Models.DTOs.Consultas
{
    public class ProductoDTO
    {
        public int PK_ID_PRODUCTO { get; set; }
        public string NOMBRE_PRODUC { get; set; }
        public Nullable<int> CANTIDAD { get; set; }
        public string REFERENCIA { get; set; }
        public Nullable<double> PRECIO { get; set; }
        public Nullable<System.DateTime> FECHA { get; set; }
        public Nullable<double> IVA { get; set; }

    }
}