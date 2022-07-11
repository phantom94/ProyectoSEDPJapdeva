using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoSEDP.Controllers
{
    public class PerfilController : Controller
    {
        public IActionResult Perfiles()
        {
            return View();
        }

        public ActionResult Put([FromBody] Models.Perfil model)
        {
            using (Models.CrudSEDPContext db = new Models.CrudSEDPContext())
            {
                Models.Perfil oPerfil = db.Perfils.Find(model.CodigoPerfil);
                oPerfil.NombrePerfil = model.NombrePerfil;
                oPerfil.DescripcionPerfil = model.DescripcionPerfil;
                db.Entry(oPerfil).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }

            return Ok();
        }


        public ActionResult Post([FromBody] Models.Perfil model)
        {
            using (Models.CrudSEDPContext db = new Models.CrudSEDPContext())
            {
                Models.Perfil oPerfil = new Models.Perfil();
                oPerfil.NombrePerfil = model.NombrePerfil;
                oPerfil.DescripcionPerfil = model.DescripcionPerfil;
                db.Perfils.Add(oPerfil);
                db.SaveChanges();
            }

            return Ok();
        }
        public ActionResult Get()
        {
            using (Models.CrudSEDPContext db = new Models.CrudSEDPContext())
            {
                var lst = (from d in db.Perfils
                           select d).ToList();

                return Ok(lst);
            }

        }
    }
}
