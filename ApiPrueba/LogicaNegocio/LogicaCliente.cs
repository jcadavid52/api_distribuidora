using ApiPrueba.Interfaces;
using ApiPrueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiPrueba.LogicaNegocio
{
    public class LogicaCliente:ICrud<CLIENTE>
    {
        //lista cliente

        public List<CLIENTE> Listar()
        {
            using (BD_BODEGAEntities bd = new BD_BODEGAEntities())
            {
                return bd.CLIENTE.ToList();
            }
        }

        //consultar cliente
        public  CLIENTE Consultar(int id)
        {
            using (BD_BODEGAEntities bd = new BD_BODEGAEntities())
            {
                return  bd.CLIENTE.FirstOrDefault(c => c.PK_ID_CLIENTE == id);
            }
        }

        //insertar cliente

        public  bool Insertar(CLIENTE nuevoCliente)
        {
            using (BD_BODEGAEntities bd = new BD_BODEGAEntities())
            {
                try
                {

                    bd.CLIENTE.Add(nuevoCliente);
                    bd.SaveChanges();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        //actualizar cliente
        public  bool Actualizar(CLIENTE Cliente)
        {
            using (BD_BODEGAEntities bd = new BD_BODEGAEntities())
            {
                try
                {

                    bd.Entry(Cliente).State = System.Data.Entity.EntityState.Modified;
                    bd.SaveChanges();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

        }

        public  bool Eliminar(CLIENTE nuevoCliente)
        {
            using (BD_BODEGAEntities bd = new BD_BODEGAEntities())
            {
                try
                {

                    bd.Entry(nuevoCliente).State = System.Data.Entity.EntityState.Deleted;
                    bd.SaveChanges();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

       
    }
}