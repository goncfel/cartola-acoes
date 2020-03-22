using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APICartola.Model;

namespace APICartola.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcaoController : ControllerBase
    {
        private readonly CartolaContext _context;

        public AcaoController(CartolaContext context)
        {
            _context = context;
        }

        // GET: api/Acao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Acao>>> GetAcao()
        {
            return await _context.Acao.ToListAsync();
        }

        // GET: api/Acao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Acao>> GetAcao(int id)
        {
            var acao = await _context.Acao.FindAsync(id);

            if (acao == null)
            {
                return NotFound();
            }

            return acao;
        }

        // PUT: api/Acao/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcao(int id, Acao acao)
        {
            if (id != acao.id)
            {
                return BadRequest();
            }

            _context.Entry(acao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcaoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Acao
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Acao>> PostAcao(Acao acao)
        {
            _context.Acao.Add(acao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAcao", new { id = acao.id }, acao);
        }

        // DELETE: api/Acao/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Acao>> DeleteAcao(int id)
        {
            var acao = await _context.Acao.FindAsync(id);
            if (acao == null)
            {
                return NotFound();
            }

            _context.Acao.Remove(acao);
            await _context.SaveChangesAsync();

            return acao;
        }

        private bool AcaoExists(int id)
        {
            return _context.Acao.Any(e => e.id == id);
        }
    }
}
