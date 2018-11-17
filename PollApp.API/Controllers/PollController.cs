﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PollApp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PollController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Teste");
        }
    }
}