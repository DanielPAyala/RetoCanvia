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
    public class CarreraController : ControllerBase
    {
        private CarreraService _carreraService = new CarreraService();

        // GET: api/<CarreraController>
        [HttpGet]
        public IEnumerable<CarreraModel> Get()
        {
            return _carreraService.Consultar();
        }

        // GET api/<CarreraController>/5
        [HttpGet("{id}")]
        public CarreraModel Get(int id)
        {
            return _carreraService.BuscarPorId(id);
        }

        // POST api/<CarreraController>
        [HttpPost]
        public void Post([FromBody] CarreraModel value)
        {
            _carreraService.Guardar(value);
        }

        // PUT api/<CarreraController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CarreraModel value)
        {
            _carreraService.Actualizar(value);
        }

        // DELETE api/<CarreraController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _carreraService.Eliminar(id);
        }
    }
}
