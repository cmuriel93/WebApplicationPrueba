using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationPrueba.Data;
using WebApplicationPrueba.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmpleadosController(AppDbContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //// GET: Productos
        //public List<Empleados> GetProducts()
        //{
        //    List<Empleados> productos = _context.empleados.ToList();

        //    return productos;
        //}

        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                //var a = GetProducts();
                var empleado = _context.empleados.ToList();
                return Ok(_context.empleados.ToArray());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }              
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}", Name="GetEmpleado")]
        public ActionResult Get(string documento)
        {
            try
            {
                var empleado = _context.empleados.FirstOrDefault(x => x.numeroDocumento == documento);
                return Ok(_context.empleados.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            //return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult Post([FromBody] Empleados empleados)
        {
            //Empleados empleados = ; 

            try
            {
                _context.empleados.Add(empleados);
                _context.SaveChanges();                     
                return CreatedAtRoute("GetEmpleado", new { id = empleados.numeroDocumento }, empleados);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Empleados empleados)
        {
            try
            {
                _context.empleados.Add(empleados);
                _context.SaveChanges();
                return CreatedAtRoute("GetEmpleado", new { id = empleados.numeroDocumento }, empleados);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string documento)
        {
            try
            {
                var empleado = _context.empleados.FirstOrDefault(x => x.numeroDocumento == documento);

                if (empleado != null)
                {
                    _context.empleados.Remove(empleado);
                    _context.SaveChanges();
                    return Ok(documento);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
