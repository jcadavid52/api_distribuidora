using ApiPrueba.Models;
using ApiPrueba.Models.DTOs.Agregar_datos;
using ApiPrueba.Models.DTOs.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiPrueba.Controllers
{
    public class FacturaController : ApiController
    {
        // POST api/<controller>
        public IHttpActionResult Add([FromBody] FacturaDTO nuevaFactura)
        {
            var oLogicaDetalle = new LogicaNegocio.LogicaDetalleFactura();
            var existenciaFactura = oLogicaDetalle.ConsultarDetallePorCiente(nuevaFactura.fk_cliente);
            var valoresNullos = false;
           
            var oFactura = new LogicaNegocio.LogicaFactura();




            foreach (var item in existenciaFactura)
            {
                if (item.FK_ID_FACTURA == null)
                {
                   
                    valoresNullos = true;
                }
            }


            if (valoresNullos)
            {
                var id_factura = oFactura.InsertarFacturaSP(nuevaFactura);
                if (id_factura != null)
                {
                   return Ok(new { id_factura = id_factura });

                }
                else
                {
                    return null;
                }
            }
            else
            {
                return Ok(new { mensaje = "0" });
            }

   

        }

        public IHttpActionResult Get(int id)
        {
            var logicaFactura = new LogicaNegocio.LogicaFactura();

            var datosFactura = logicaFactura.ConsultarFactura(id);




            //comprueba que no haya una excepcion en la logica factura
            if (datosFactura != null)
            {
                //comprueba que si arroge resultados de la consulta
                if (datosFactura.Count > 0)
                {

                    //declaro variables para ordenar el archivo json
                    double? total = 0;
                    double? Subtotal = 0;
                    int codigo_factura = 0;


                    //obtengo datos de la consulta y las igualo a las variables declaradas arriba
                    foreach (var item in datosFactura)
                    {
                        total = item.TOTAL;
                        codigo_factura = item.codigo_factura;
                        Subtotal = item.SUBTOTAL;
                    }



                    //ordeno los datos que me arrojo la consulta con linq, para que me separe lo que es lista de lo que no es lista
                    //como en el caso de total, subtotal, codigo_factura, ya que la consulta desde sql con el SP, me los trae en lista
                    // y se necesitaban solamente en varable
                    var listaDtsOrde = from cust in datosFactura

                                       select new
                                       {
                                           cust.nombre_producto,
                                           cust.precio_unidad,
                                           cust.cantidad,
                                           cust.SubTotal_por_unidad,
                                           cust.Total_por_Unidad

                                       };
                    //retorno en orden los datos que se verán reflejados en formato json
                    return Ok(new
                    {
                        codigo_factura = codigo_factura,
                        subTotal = Subtotal,
                        total = total,

                        datosTablaFactura = listaDtsOrde
                    });
                }
                else
                {

                    return NotFound();

                }

            }

            return NotFound();



        }



    }
}
