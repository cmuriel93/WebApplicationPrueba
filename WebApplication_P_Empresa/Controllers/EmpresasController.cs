using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebApplication_P_Empresa.Data;
using WebApplication_P_Empresa.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication_P_Empresa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmpresasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/<EmpresasController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                //var a = GetProducts();
                var empleado = _context.empresas.ToList();
                return Ok(_context.empresas.ToArray());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<EmpresasController>/5
        [HttpGet("{id}")]
        public ActionResult Get(string documento)
        {
            try
            {
                var empleado = _context.empresas.FirstOrDefault(x => x.nit == documento);
                return Ok(_context.empresas.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<EmpresasController>
        [HttpPost]
        public ActionResult Post([FromBody] Empresas empresas)
        {
            //Empleados empleados = ; 

            try
            {
                _context.empresas.Add(empresas);
                _context.SaveChanges();
                return CreatedAtRoute("GetEmpleado", new { id = empresas.nit }, empresas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<EmpresasController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Empresas empresas)
        {
            try
            {
                _context.empresas.Add(empresas);
                _context.SaveChanges();
                return CreatedAtRoute("GetEmpleado", new { id = empresas.nit }, empresas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<EmpresasController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string documento)
        {
            try
            {
                var empleado = _context.empresas.FirstOrDefault(x => x.nit == documento);

                if (empleado != null)
                {
                    _context.empresas.Remove(empleado);
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
