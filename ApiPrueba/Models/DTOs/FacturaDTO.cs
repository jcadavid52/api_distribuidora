using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiPrueba.Models.DTOs.Agregar_datos
{
    public class FacturaDTO
    {
       
        public FacturaDTO()
        {
            this.FECHA_FACTURA = DateTime.Now;
        }
        public Nullable<System.DateTime> FECHA_FACTURA { get; set; }
        public string INFORME_VENTA { get; set; }

        public int fk_cliente { get; set; }


    }
}