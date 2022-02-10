using Catalogo.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Catalogo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoController : ControllerBase
    {
        private readonly AplicationDbContext aplicationDbContext;

        public CatalogoController(AplicationDbContext aplicationDbContext)
        {
            this.aplicationDbContext = aplicationDbContext;
        }
        // GET: api/<CatalogoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listContenido = await aplicationDbContext.Contenido.ToListAsync();
                return Ok(listContenido);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<CatalogoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Contenido contenido)
        {
            try
            {
                aplicationDbContext.Add(contenido);
                await aplicationDbContext.SaveChangesAsync();
                return Ok(contenido);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CatalogoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Contenido contenido)
        {
            try
            {
                if (id != contenido.Id)
                {
                    return NotFound();
                }

                aplicationDbContext.Update(contenido);
                await aplicationDbContext.SaveChangesAsync();
                return Ok(new {message = "La" + contenido.clase_producto + " " + contenido.nombre +" actualizada con exito" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CatalogoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var contenido = await aplicationDbContext.Contenido.FindAsync(id);
                if (contenido == null)
                {
                    return NotFound();
                }
                aplicationDbContext.Contenido.Remove(contenido);
                await aplicationDbContext.SaveChangesAsync();
                return Ok(new { message = "La" + contenido.clase_producto + " " + contenido.nombre + " eliminada con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
