using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoSEDP.Controllers
{
    public class EvaluacionController : Controller
    {
        public IActionResult Evaluaciones()
        {
            return View();
        }

        public IActionResult Evaluacion()
        {
            return View();
        }

        public IActionResult Pendientes()
        {
            return View();
        }

        public IActionResult Historico()
        {
            return View();
        }
    }
}
