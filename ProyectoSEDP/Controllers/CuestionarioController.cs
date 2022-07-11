using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoSEDP.Controllers
{
    public class CuestionarioController : Controller
    {
        public IActionResult Cuestionarios()
        {
            return View();
        }
    }
}
