using ApiPrueba.Interfaces;
using ApiPrueba.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ApiPrueba.LogicaNegocio
{
    public class LogicaUsuario:ICrud<USUARIO>
    {
        public bool Actualizar(USUARIO modifiedModel)
        {
            throw new NotImplementedException();
        }

        public USUARIO Consultar(int id)
        {
            using (BD_BODEGAEntities bd = new BD_BODEGAEntities())
            {
                try
                {
                    var usuario = bd.USUARIO.FirstOrDefault(u => u.PK_ID_USUARIO == id);

                    return usuario;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public bool Eliminar(USUARIO deleteModel)
        {
            throw new NotImplementedException();
        }

        public bool Insertar(USUARIO createModel)
        {
            
            using (BD_BODEGAEntities bd = new BD_BODEGAEntities())
            {
                try
                {
                    bd.USUARIO.Add(createModel);
                    bd.SaveChanges();
                    return true;
                }
                catch(Exception e) 
                {
                    string ecxc = e.ToString();
                    return false;
                }
            }
        }

        public List<USUARIO> Listar()
        {
            using (BD_BODEGAEntities bd = new BD_BODEGAEntities())
            {
                return bd.USUARIO.ToList();
            }
        }

        public bool Autenticar(USUARIO User)
        {
            using (BD_BODEGAEntities bd = new BD_BODEGAEntities())
            {
                try
                {

                     var validar = bd.USUARIO.FirstOrDefault(x => x.USUARIO1 == User.USUARIO1 && x.CLAVE == User.CLAVE);
                     
                    if(validar != null && validar.ESTADO == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }catch(Exception ex)
                {
                    return false;
                }

            }
        }

        //obtiene pk del usuario
        public USUARIO GetPkUser(string user)
        {
            using (BD_BODEGAEntities bd = new BD_BODEGAEntities())
            {
                try
                {
                    return bd.USUARIO.FirstOrDefault(x => x.USUARIO1 == user && x.ESTADO == true);
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}