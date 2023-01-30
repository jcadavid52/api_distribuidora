using ApiPrueba.Interfaces;
using ApiPrueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiPrueba.LogicaNegocio
{
    public class LogicaProducto:ICrud<PRODUCTO>
    {
        public bool Actualizar(PRODUCTO modifiedModel)
        {
            throw new NotImplementedException();
        }

        public PRODUCTO Consultar(int id)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(PRODUCTO deleteModel)
        {
            throw new NotImplementedException();
        }

        public bool Insertar(PRODUCTO createModel)
        {
            throw new NotImplementedException();
        }

        public List<PRODUCTO> Listar()
        {
            using (BD_BODEGAEntities bd = new BD_BODEGAEntities())
            {
                return bd.PRODUCTO.ToList();
            }
        }
    }
}