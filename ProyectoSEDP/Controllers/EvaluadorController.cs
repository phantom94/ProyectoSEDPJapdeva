﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoSEDP.Controllers
{
    public class EvaluadorController : Controller
    {
        public IActionResult Evaluadores()
        {
            return View();
        }
    }
}
