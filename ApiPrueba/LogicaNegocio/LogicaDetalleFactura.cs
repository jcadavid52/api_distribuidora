using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ApiPrueba.Interfaces;
using ApiPrueba.Models;

namespace ApiPrueba.LogicaNegocio
{
    public class LogicaDetalleFactura:ICrud<DETALLE_FACT>
    {
        //Listar detalle factura
        public List<DETALLE_FACT> Listar()
        {
            using (BD_BODEGAEntities BD = new BD_BODEGAEntities())
            {
                return BD.DETALLE_FACT.Include("CLIENTE").Include("PRODUCTO").Include("USUARIO").Include("FACTURA").ToList();
            }

            
        }

        //insertar detalle factura

        public  bool Insertar(DETALLE_FACT nuevoDetalle)
        {
            using (BD_BODEGAEntities BD = new BD_BODEGAEntities())
            {
                try
                {
                    BD.SP_INSERTAR_DETALLE_FACT(nuevoDetalle.CANTIDAD_PRODUCTO,nuevoDetalle.DESCUENTO,nuevoDetalle.FK_ID_USUARIO,nuevoDetalle.FK_ID_PRODUCTO,nuevoDetalle.FK_ID_CLIENTE);
                    BD.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public DETALLE_FACT Consultar(int id)
        {
            throw new NotImplementedException();
        }

        public bool Actualizar(DETALLE_FACT modifiedModel)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(DETALLE_FACT deleteModel)
        {
            throw new NotImplementedException();
        }

        //consulta todas las foraneas de tabla detalle factura con el id del cliente, para obtener luego los producto en la plantilla
        //de la factura
        public List<DETALLE_FACT> ConsultarDetallePorCiente(int id)
        {
            using (BD_BODEGAEntities db = new BD_BODEGAEntities())
            {
                return db.DETALLE_FACT.Where(x => x.FK_ID_CLIENTE == id).ToList();
            }
        }

    }
}