using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoSEDP.Controllers
{    //[Route("Home/[controller]")]
     //[EnableCors("permitir")]
    public class UsuarioController : Controller
    {
        public IActionResult Usuarios()
        {
            return View();
        }

        public ActionResult Logeo([FromBody] Models.Request.RolRequest model)
        {
            using (Models.CrudSEDPContext db = new Models.CrudSEDPContext())
            {
                var lst = from d in db.Usuarios
                          where d.CorreoUsuario == model.correoUsuario
                          && d.ContrasennaUsuario == model.contrasennaUsuario
                          select d;
                var lstprueba = (from d in db.Usuarios
                                 where d.CorreoUsuario == model.correoUsuario
                                 && d.ContrasennaUsuario == model.contrasennaUsuario
                                 select d).ToList();
                if (lst.Count()>0)
                {
                    Console.WriteLine("Usuario Existe");
                    return Ok(lstprueba);
                }
                else
                {
                    Console.WriteLine("Usuario No Existe");
                }
                return Ok();
            }
           
        }

        public ActionResult Get()
        {
            using (Models.CrudSEDPContext db = new Models.CrudSEDPContext())
            {
                var lst = (from d in db.Usuarios
                           select d).ToList();
               
                return Ok(lst);
            }

        }

        public ActionResult Post([FromBody] Models.Request.RolRequest model)
        {
            using (Models.CrudSEDPContext db = new Models.CrudSEDPContext())
            {
                Models.Usuario oUsuario = new Models.Usuario();
                oUsuario.NombreUsuario = model.nombreUsuario;
                oUsuario.CorreoUsuario = model.correoUsuario;
                oUsuario.ContrasennaUsuario = model.contrasennaUsuario;
                oUsuario.FotoUsuario = model.fotoUsuario;
                db.Usuarios.Add(oUsuario);
                db.SaveChanges();
            }

            return Ok();
        }

        //El que edita
        public ActionResult Put([FromBody] Models.Request.UsuarioEditRequest model)
        {
            using (Models.CrudSEDPContext db = new Models.CrudSEDPContext())
            {
                Models.Usuario oUsuario = db.Usuarios.Find(model.codigoUsuario);
                oUsuario.NombreUsuario = model.nombreUsuario;
                oUsuario.CorreoUsuario = model.correoUsuario;
                oUsuario.ContrasennaUsuario = model.contrasennaUsuario;
                oUsuario.FotoUsuario = model.fotoUsuario;
                db.Entry(oUsuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }

            return Ok();
        }

        //El que elimina
        public ActionResult Delete([FromBody] Models.Request.UsuarioEditRequest model)
        {
            using (Models.CrudSEDPContext db = new Models.CrudSEDPContext())
            {
                Models.Usuario oUsuario = db.Usuarios.Find(model.codigoUsuario);
                db.Usuarios.Remove(oUsuario);
                db.SaveChanges();
            }

            return Ok();
        }

    }
}
