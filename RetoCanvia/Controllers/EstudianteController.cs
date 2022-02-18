using Microsoft.AspNetCore.Mvc;
using RetoCanvia.Models;
using RetoCanvia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RetoCanvia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private EstudianteService _estudianteService = new EstudianteService();

        // GET: api/<EstudianteController>
        [HttpGet]
        public IEnumerable<EstudianteModel> Get()
        {
            return _estudianteService.Consultar(); ;
        }

        // GET api/<EstudianteController>/5
        [HttpGet("{id}")]
        public EstudianteModel Get(int id)
        {
            return _estudianteService.BuscarPorId(id);
        }

        // POST api/<EstudianteController>
        [HttpPost]
        public void Post([FromBody] EstudianteModel value)
        {
            _estudianteService.Guardar(value);
        }

        // PUT api/<EstudianteController>/5
        [HttpPut]
        public void Put([FromBody] EstudianteModel value)
        {
            _estudianteService.Actualizar(value);
        }

        // DELETE api/<EstudianteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _estudianteService.Eliminar(id);
        }
    }
}
