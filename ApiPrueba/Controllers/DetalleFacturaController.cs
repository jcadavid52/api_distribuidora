using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using ApiPrueba.Utilidades;
using System.Web.Http;
using ApiPrueba.Models;
using ApiPrueba.Models.DTOs.Consultas;
using ApiPrueba.Models.DTOs.Agregar_datos;

namespace ApiPrueba.Controllers
{
    [Authorize]
    public class DetalleFacturaController : ApiController
    {

        //GET api/<controller>

        [HttpGet]
        public IHttpActionResult Get()
        {
            //obtiene datos directamente de la base de datos = tarea 1 de este metodo
            var oDatos = new LogicaNegocio.LogicaDetalleFactura();
            var datos = oDatos.Listar();
            /*instancia objeto lista de DTO para retornar una vez se igualen a los
            datos obtenidos directamente de la base de datos*/
            List<DetalleFacturaDTO> datosFactura = new List<DetalleFacturaDTO>();

            foreach (var items in datos)
            {
                DetalleFacturaDTO oDetalleFactura = new DetalleFacturaDTO();

                //datos detalle factura
                oDetalleFactura.PK_ID_DETALLE_FACT = items.PK_ID_DETALLE_FACT;
                oDetalleFactura.CANTIDAD_PRODUCTO = items.CANTIDAD_PRODUCTO;
                oDetalleFactura.SUBTOTAL = items.SUBTOTAL;
                oDetalleFactura.DESCUENTO = items.DESCUENTO;
                oDetalleFactura.VALOR_TOTAL = items.VALOR_TOTAL;
                oDetalleFactura.IVA_DETALLE_FACT = items.IVA_DETALLE_FACT;

                //datos cliente

                oDetalleFactura.FK_ID_CLIENTE = items.CLIENTE.PK_ID_CLIENTE;
                oDetalleFactura.NOMBRES = items.CLIENTE.NOMBRES;
                oDetalleFactura.APELLIDOS = items.CLIENTE.APELLIDOS;
                oDetalleFactura.DIRECCION = items.CLIENTE.DIRECCION;
                oDetalleFactura.TELEFONO = items.CLIENTE.TELEFONO;
                oDetalleFactura.CORREO = items.CLIENTE.CORREO;

                //datos usuarios

                oDetalleFactura.FK_ID_USUARIO = items.USUARIO.PK_ID_USUARIO;
                oDetalleFactura.USUARIO1 = items.USUARIO.USUARIO1;
                oDetalleFactura.CLAVE = items.USUARIO.CLAVE;
                oDetalleFactura.ESTADO = items.USUARIO.ESTADO;

                //datos producto

                oDetalleFactura.FK_ID_PRODUCTO = items.PRODUCTO.PK_ID_PRODUCTO;
                oDetalleFactura.NOMBRE_PRODUC = items.PRODUCTO.NOMBRE_PRODUC;
                oDetalleFactura.CANTIDAD = items.PRODUCTO.CANTIDAD;
                oDetalleFactura.REFERENCIA = items.PRODUCTO.REFERENCIA;
                oDetalleFactura.PRECIO = items.PRODUCTO.PRECIO;
                oDetalleFactura.FECHA = items.PRODUCTO.FECHA;
                oDetalleFactura.IVA = items.PRODUCTO.IVA;

                //datos factura

                if (items.FK_ID_FACTURA != null)
                {
                    oDetalleFactura.FK_ID_FACTURA = items.FACTURA.PK_ID_FACTURA;
                    oDetalleFactura.FECHA_FACTURA = items.FACTURA.FECHA_FACTURA;
                    oDetalleFactura.INFORME_VENTA = items.FACTURA.INFORME_VENTA;
                }

                datosFactura.Add(oDetalleFactura);
            }

            return Ok(datosFactura);


        }

        // GET api/<controller>/5   
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public HttpResponseMessage Add([FromBody] DetalleFacturaDTO nuevoDetalle)
        {
            if (ModelState.IsValid)
            {
                var miDetalle = new DETALLE_FACT();

                miDetalle.CANTIDAD_PRODUCTO = nuevoDetalle.CANTIDAD_PRODUCTO;
                miDetalle.DESCUENTO = nuevoDetalle.DESCUENTO;
                miDetalle.FK_ID_CLIENTE = nuevoDetalle.FK_ID_CLIENTE;
                miDetalle.FK_ID_USUARIO = nuevoDetalle.FK_ID_USUARIO;
                miDetalle.FK_ID_FACTURA = nuevoDetalle.FK_ID_FACTURA;
                miDetalle.FK_ID_PRODUCTO = nuevoDetalle.FK_ID_PRODUCTO;

                var oDetalle = new LogicaNegocio.LogicaDetalleFactura();



               var registrado = oDetalle.Insertar(miDetalle);

                if (registrado) {
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error en el servidor");
                }
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }


    }
}