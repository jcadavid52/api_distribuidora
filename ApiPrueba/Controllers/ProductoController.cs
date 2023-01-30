using ApiPrueba.LogicaNegocio;
using ApiPrueba.Models.DTOs.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiPrueba.Controllers
{
    public class ProductoController : ApiController
    {
        public IHttpActionResult Get()
        {
            var oProductos = new LogicaProducto();
            var productos = oProductos.Listar();

            var listaProductos = new List<ProductoDTO>();

            foreach (var item in productos)
            {
                var Oproducto = new ProductoDTO();

                Oproducto.PK_ID_PRODUCTO = item.PK_ID_PRODUCTO;
                Oproducto.NOMBRE_PRODUC = item.NOMBRE_PRODUC;
                Oproducto.CANTIDAD = item.CANTIDAD;
                Oproducto.REFERENCIA = item.REFERENCIA;
                Oproducto.PRECIO = item.PRECIO;
                Oproducto.FECHA = item.FECHA;
                Oproducto.IVA = item.IVA;
                listaProductos.Add(Oproducto);
            }

            return Ok(listaProductos);
        }
    }
}
