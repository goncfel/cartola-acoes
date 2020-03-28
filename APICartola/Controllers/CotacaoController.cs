using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APICartola.Model;
using APICartola.ViewModel;

namespace APICartola.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CotacaoController : ControllerBase
    {
        private readonly CartolaContext _context;

        public CotacaoController(CartolaContext context)
        {
            _context = context;
        }

        // GET: api/Cotacaos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cotacao>>> GetCotacao()
        {
            List<Cotacao> lista = new List<Cotacao>();
            if (_context.Cotacao.Count() > 0)
                return await _context.Cotacao.ToListAsync();

            return lista;
        }

        // GET: api/Cotacaos/5
        [HttpGet("{semana}")]
        public ActionResult<List<responseCotacao>> GetCotacao(int semana)
        {
            List<Cotacao> cotacoes = _context.Cotacao.Where(x => x.semana == semana).ToList();


            if (cotacoes == null)
            {
                return NotFound();
            }

            List<responseCotacao> responseCotacao = new List<responseCotacao>();

            foreach(Cotacao item in cotacoes)
            {
                responseCotacao.Add(new responseCotacao()
                {
                    id = item.idAcao,
                    codAcao = _context.Acao.Where(x => x.id == item.idAcao).Select(x => x.codAcao).FirstOrDefault(),
                    cotacao = item.cotacao,
                    dataCotacao = item.dataCotacao.ToString("dd/MM/yyyy"),
                    variacao = item.variacao
                });
            }

            return responseCotacao;
        }

        // PUT: api/Cotacaos/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCotacao(int id, Cotacao cotacao)
        {
            if (id != cotacao.id)
            {
                return BadRequest();
            }

            _context.Entry(cotacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CotacaoExists(id))
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

        // POST: api/Cotacaos
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Cotacao>> PostCotacao(Cotacao cotacao)
        {
            _context.Cotacao.Add(cotacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCotacao", new { id = cotacao.id }, cotacao);
        }

        // DELETE: api/Cotacaos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cotacao>> DeleteCotacao(int id)
        {
            var cotacao = await _context.Cotacao.FindAsync(id);
            if (cotacao == null)
            {
                return NotFound();
            }

            _context.Cotacao.Remove(cotacao);
            await _context.SaveChangesAsync();

            return cotacao;
        }

        private bool CotacaoExists(int id)
        {
            return _context.Cotacao.Any(e => e.id == id);
        }
    }
}
