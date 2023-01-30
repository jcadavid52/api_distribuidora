using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiPrueba.Models.DTOs.Consultas
{
    public class ClienteDTO
    {
        public int PK_ID_CLIENTE { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDOS { get; set; }
        public string DIRECCION { get; set; }
        public string TELEFONO { get; set; }
        public string CORREO { get; set; }
    }
}