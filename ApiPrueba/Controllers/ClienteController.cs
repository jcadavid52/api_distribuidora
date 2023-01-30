using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiPrueba.LogicaNegocio;

using ApiPrueba.Models.DTOs.Consultas;

namespace ApiPrueba.Controllers
{
    public class ClienteController : ApiController
    {
        public IHttpActionResult Get()
        {
            var oClientes = new LogicaCliente();
            var clientes = oClientes.Listar();

            var listaClientes = new List<ClienteDTO>();

            foreach (var item in clientes)
            {
                var Ocliente = new ClienteDTO();

                Ocliente.PK_ID_CLIENTE = item.PK_ID_CLIENTE;
                Ocliente.NOMBRES = item.NOMBRES;
                Ocliente.APELLIDOS = item.APELLIDOS;
                Ocliente.DIRECCION = item.DIRECCION;
                Ocliente.TELEFONO = item.TELEFONO;
                Ocliente.CORREO = item.CORREO;
                listaClientes.Add(Ocliente);
            }

            return Ok(listaClientes);
        }

        public IHttpActionResult Get(int id)
        {
            var oCliente = new LogicaCliente();

            var cliente = oCliente.Consultar(id);

            var clienteDTO = new ClienteDTO();

            clienteDTO.PK_ID_CLIENTE = cliente.PK_ID_CLIENTE;
            clienteDTO.NOMBRES = cliente.NOMBRES;
            clienteDTO.APELLIDOS = cliente.APELLIDOS;
            clienteDTO.DIRECCION = cliente.DIRECCION;
            clienteDTO.TELEFONO = cliente.TELEFONO;
            clienteDTO.CORREO = cliente.CORREO;

            return Ok(clienteDTO);
        }
    }
}
