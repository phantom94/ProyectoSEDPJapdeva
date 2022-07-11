using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoSEDP.Controllers
{
    public class DepartamentoController : Controller
    {
        public IActionResult Departamentos()
        {
            return View();
        }

        public ActionResult Put([FromBody] Models.Departamento model)
        {
            using (Models.CrudSEDPContext db = new Models.CrudSEDPContext())
            {
                Models.Departamento oDepartamento = db.Departamentos.Find(model.CodigoDepartamento);
                oDepartamento.NombreDepartamento = model.NombreDepartamento;
                oDepartamento.DescripcionDepartamento = model.DescripcionDepartamento;
                db.Entry(oDepartamento).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }

            return Ok();
        }

        public ActionResult Post([FromBody] Models.Departamento model)
        {
            using (Models.CrudSEDPContext db = new Models.CrudSEDPContext())
            {
                Models.Departamento oDepartamento = new Models.Departamento();
                oDepartamento.NombreDepartamento = model.NombreDepartamento;
                oDepartamento.DescripcionDepartamento = model.DescripcionDepartamento;
                db.Departamentos.Add(oDepartamento);
                db.SaveChanges();
            }

            return Ok();
        }

        public ActionResult Get()
        {
            using (Models.CrudSEDPContext db = new Models.CrudSEDPContext())
            {
                var lst = (from d in db.Departamentos
                           select d).ToList();

                return Ok(lst);
            }

        }
    }
}
