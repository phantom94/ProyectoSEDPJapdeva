using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoSEDP.Controllers
{
    public class RolController : Controller
    {
        public IActionResult Roles()
        {
            return View();
        }

        public ActionResult Post([FromBody] Models.Rol model)
        {
            using (Models.CrudSEDPContext db = new Models.CrudSEDPContext())
            {
                Models.Rol oRol = new Models.Rol();
                oRol.NombreRol = model.NombreRol;
                oRol.DescripcionRol = model.DescripcionRol;
                db.Rols.Add(oRol);
                db.SaveChanges();
            }

            return Ok();
        }

        public ActionResult Get()
        {
            using (Models.CrudSEDPContext db = new Models.CrudSEDPContext())
            {
                var lst = (from d in db.Rols
                           select d).ToList();

                return Ok(lst);
            }

        }

        public ActionResult Put([FromBody] Models.Rol model)
        {
            using (Models.CrudSEDPContext db = new Models.CrudSEDPContext())
            {
                Models.Rol oRol = db.Rols.Find(model.CodigoRol);
                oRol.NombreRol = model.NombreRol;
                oRol.DescripcionRol = model.DescripcionRol;
                db.Entry(oRol).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }

            return Ok();
        }
    }

}
