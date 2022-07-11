using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoSEDP.Controllers
{
    public class CriterioController : Controller
    {
        public IActionResult Criterios()
        {
            return View();
        }

        public ActionResult Put([FromBody] Models.Criterio model)
        {
            using (Models.CrudSEDPContext db = new Models.CrudSEDPContext())
            {
                Models.Criterio oCriterio = db.Criterios.Find(model.CodigoCriterio);
                oCriterio.DescripcionCriterio = model.DescripcionCriterio;
                oCriterio.PesoCriterio = model.PesoCriterio;
                db.Entry(oCriterio).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }

            return Ok();
        }

        public ActionResult Get()
        {
            using (Models.CrudSEDPContext db = new Models.CrudSEDPContext())
            {
                var lst = (from d in db.Criterios
                           select d).ToList();

                return Ok(lst);
            }

        }

        public ActionResult Post([FromBody] Models.Criterio model)
        {
            using (Models.CrudSEDPContext db = new Models.CrudSEDPContext())
            {
                Models.Criterio oCriterio = new Models.Criterio();
                oCriterio.DescripcionCriterio = model.DescripcionCriterio;
                oCriterio.PesoCriterio = model.PesoCriterio;
                db.Criterios.Add(oCriterio);
                db.SaveChanges();
            }

            return Ok();
        }
    }
}
