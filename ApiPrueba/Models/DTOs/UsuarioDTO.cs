using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiPrueba.Models.DTOs.Consultas
{
    public class UsuarioDTO
    {
        public int PK_ID_USUARIO { get; set; }
        public string USUARIO1 { get; set; }
        public string CLAVE { get; set; }
        public Nullable<bool> ESTADO { get; set; }
        public Nullable<int> FK_ID_EMPLEADO { get; set; }
        public Nullable<int> FK_ID_CARGO { get; set; }
    }
}