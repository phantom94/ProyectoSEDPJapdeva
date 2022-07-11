using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoSEDP.Controllers
{
    public class CompetenciaController : Controller
    {
        public IActionResult Competencias()
        {
            return View();
        }

        public ActionResult Put([FromBody] Models.Competencia model)
        {
            using (Models.CrudSEDPContext db = new Models.CrudSEDPContext())
            {
                Models.Competencia oCompetencias = db.Competencia.Find(model.CodigoCompetencia);
                oCompetencias.NombreCompetencia = model.NombreCompetencia;
                oCompetencias.DescripcionCompetencia = model.DescripcionCompetencia;
                db.Entry(oCompetencias).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }

            return Ok();
        }

        public ActionResult Get()
        {
            using (Models.CrudSEDPContext db = new Models.CrudSEDPContext())
            {
                var lst = (from d in db.Competencia
                           select d).ToList();

                return Ok(lst);
            }

        }
        public ActionResult Post([FromBody] Models.Competencia model)
        {
            using (Models.CrudSEDPContext db = new Models.CrudSEDPContext())
            {
                Models.Competencia oCompetencia = new Models.Competencia();
                oCompetencia.NombreCompetencia = model.NombreCompetencia;
                oCompetencia.DescripcionCompetencia = model.DescripcionCompetencia;
                db.Competencia.Add(oCompetencia);
                db.SaveChanges();
            }

            return Ok();
        }
    }
}
