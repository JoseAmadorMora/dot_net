﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using backend_lab_C10421.Models;
using backend_lab.Handlers;

namespace backend_lab_C10421.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        private readonly PaisesHandler _paisesHandler;

        public PaisesController()
        {
            _paisesHandler = new PaisesHandler();
        }

        [HttpGet]
        public List<PaisModel> Get()
        {
            var paises = _paisesHandler.ObtenerPaises();
            return paises;
        }
    }
}
