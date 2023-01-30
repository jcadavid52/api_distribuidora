using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiPrueba.Models.DTOs.Consultas
{
    public class DetalleFacturaDTO
    {
        //datos detalle factura

        public int PK_ID_DETALLE_FACT { get; set; }
        [Required]
        public Nullable<int> CANTIDAD_PRODUCTO { get; set; }

        public Nullable<double> SUBTOTAL { get; set; }
        [Required]
        public Nullable<double> DESCUENTO { get; set; }
        public Nullable<double> VALOR_TOTAL { get; set; }
        public Nullable<double> IVA_DETALLE_FACT { get; set; }

        //datos cliente
        [Required]
        public Nullable<int> FK_ID_CLIENTE { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDOS { get; set; }
        public string DIRECCION { get; set; }
        public string TELEFONO { get; set; }
        public string CORREO { get; set; }
        //datos usuario

        [Required]
        public Nullable<int> FK_ID_USUARIO { get; set; }
        public string USUARIO1 { get; set; }
        public string CLAVE { get; set; }
        public Nullable<bool> ESTADO { get; set; }


        //datos producto
        [Required]
        public Nullable<int> FK_ID_PRODUCTO { get; set; }
        public string NOMBRE_PRODUC { get; set; }
        public Nullable<int> CANTIDAD { get; set; }
        public string REFERENCIA { get; set; }
        public Nullable<double> PRECIO { get; set; }
        public Nullable<System.DateTime> FECHA { get; set; }
        public Nullable<double> IVA { get; set; }

        //datos factura
       
        public Nullable<int> FK_ID_FACTURA { get; set; }
        public Nullable<System.DateTime> FECHA_FACTURA { get; set; }
        public string INFORME_VENTA { get; set; }


    }
}