using ApiPrueba.LogicaNegocio;
using ApiPrueba.Models;
using ApiPrueba.Models.DTOs.Agregar_datos;
using ApiPrueba.Models.DTOs.Consultas;
using ApiPrueba.Utilidades;
using System.Collections.Generic;
using System.Web.Http;

namespace ApiPrueba.Controllers
{
    public class UsuarioController : ApiController
    {
        public IHttpActionResult Get()
        {
            var oUsuarios = new LogicaUsuario();
            var usuarios = oUsuarios.Listar();

            var listaUsuarios = new List<UsuarioDTO>();

            foreach (var item in usuarios)
            {
                var Ousuario = new UsuarioDTO();

                Ousuario.PK_ID_USUARIO = item.PK_ID_USUARIO;
                Ousuario.USUARIO1 = item.USUARIO1;
                Ousuario.CLAVE = item.CLAVE;
                Ousuario.ESTADO = item.ESTADO;
                Ousuario.FK_ID_EMPLEADO = item.FK_ID_EMPLEADO;
                Ousuario.FK_ID_CARGO = item.FK_ID_CARGO;
                listaUsuarios.Add(Ousuario);
            }

            return Ok(listaUsuarios);
        }

        public IHttpActionResult Get(int id)
        {
            var oLogicaUsuario = new LogicaUsuario();

            if (oLogicaUsuario.Consultar(id) != null)
            {
                var usuarioBd = oLogicaUsuario.Consultar(id);

                var usuario = new UsuarioDTO();

                usuario.PK_ID_USUARIO = usuarioBd.PK_ID_USUARIO;

                return Ok(usuario);
            }

            return NotFound();
        }

        [HttpPost]
        public bool RegistroUsuario([FromBody]UsuarioDTO model)
        {
            LogicaUsuario logicaUsuario = new LogicaUsuario();

            USUARIO oUsuario = new USUARIO();
            oUsuario.USUARIO1 = model.USUARIO1;
            oUsuario.CLAVE =  Encriptacion.GetSHA256(model.CLAVE);
            oUsuario.ESTADO = true;
            oUsuario.FK_ID_EMPLEADO = model.FK_ID_EMPLEADO;
            oUsuario.FK_ID_CARGO = model.FK_ID_CARGO;
            

           
            return logicaUsuario.Insertar(oUsuario);
        }

        [HttpPost]
        public IHttpActionResult Autenticacion([FromBody] UsuarioDTO usuarioDTO)
        {
            LogicaUsuario oLogicaUsuario = new LogicaUsuario();
            USUARIO user = new USUARIO();
            user.CLAVE = usuarioDTO.CLAVE;
            user.USUARIO1 = usuarioDTO.USUARIO1;
            

            var IsValid = oLogicaUsuario.Autenticar(user);

            if (IsValid)
            {
                var token = GenerarToken.GenerateTokenJwt(user.USUARIO1);
                return Ok(new { token = token });
            }
            else
            {
                return Unauthorized();
            }

        }
        //obtiene pk del usuario
       [HttpGet]
        public IHttpActionResult GetUserpk([FromUri] string user)
        {
            var oLogicaUsuario = new LogicaUsuario();
            var pk_user = oLogicaUsuario.GetPkUser(user);

            if (pk_user != null)
            {

                return Ok(pk_user.PK_ID_USUARIO);
            }

            return null;
        }
    }
}
