using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoSEDP.Controllers
{
    public class PreguntaController : Controller
    {
        public IActionResult Preguntas()
        {
            return View();
        }

        public ActionResult Put([FromBody] Models.Pregunta model)
        {
            using (Models.CrudSEDPContext db = new Models.CrudSEDPContext())
            {
                Models.Pregunta oPregunta = db.Pregunta.Find(model.CodigoPregunta);
                oPregunta.DescripcionPregunta = model.DescripcionPregunta;
                db.Entry(oPregunta).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }

            return Ok();
        }

        public ActionResult Get()
        {
            using (Models.CrudSEDPContext db = new Models.CrudSEDPContext())
            {
                var lst = (from d in db.Pregunta
                           select d).ToList();

                return Ok(lst);
            }

        }

        public ActionResult Post([FromBody] Models.Pregunta model)
        {
            using (Models.CrudSEDPContext db = new Models.CrudSEDPContext())
            {
                Models.Pregunta oPregunta = new Models.Pregunta();
                oPregunta.DescripcionPregunta = model.DescripcionPregunta;
                db.Pregunta.Add(oPregunta);
                db.SaveChanges();
            }

            return Ok();
        }
    }
}
