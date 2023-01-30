using ApiPrueba.Interfaces;
using ApiPrueba.Models;
using ApiPrueba.Models.DTOs.Agregar_datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiPrueba.LogicaNegocio
{
    public class LogicaFactura:ICrud<FACTURA>
    {
        #region Tablas
            public bool Actualizar(FACTURA modifiedModel)
            {
                throw new NotImplementedException();
            }

            public FACTURA Consultar(int id)
            {
                throw new NotImplementedException();
            }

            public bool Eliminar(FACTURA deleteModel)
            {
                throw new NotImplementedException();
            }

            public bool Insertar(FACTURA createModel)
            {
                throw new NotImplementedException();
            }
            public List<FACTURA> Listar()
            {
                throw new NotImplementedException();
            }
        #endregion

        #region Consultas y SP
        public List<int?> InsertarFacturaSP(FacturaDTO nuevaFactura)
        {
            using (BD_BODEGAEntities db = new BD_BODEGAEntities())
            {
                try
                {

                    var pk_factura = db.SP_AGREGAR_FACTURA2(nuevaFactura.FECHA_FACTURA, nuevaFactura.INFORME_VENTA, nuevaFactura.fk_cliente).ToList();
                    db.SaveChanges();


                    return pk_factura;

                }
                catch (Exception)
                {
                    return null;
                }

            }
        }

        public List<SP_CONSULTAR_FACTURA_Result> ConsultarFactura(int id)
        {
            using (BD_BODEGAEntities db = new BD_BODEGAEntities())
            {
                try
                {
                    return db.SP_CONSULTAR_FACTURA(id).ToList();
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
        #endregion




    }
}