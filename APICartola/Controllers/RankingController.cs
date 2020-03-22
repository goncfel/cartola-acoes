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
    public class RankingController : ControllerBase
    {
        private readonly CartolaContext _context;

        public RankingController(CartolaContext context)
        {
            _context = context;
        }


        // GET: api/Ranking/5
        [HttpGet("{idGrupo}")]
        public ActionResult<ResponseRanking> GetRanking(int idGrupo)
        {
            List<UsuarioGrupo> listaUsuarioGrupo = _context.UsuarioGrupo.Where(x => x.idGrupo == idGrupo).ToList();

            ResponseRanking responseRanking = new ResponseRanking();

            responseRanking.idGrupo = listaUsuarioGrupo.Select(x => x.idGrupo).FirstOrDefault();
            responseRanking.nomeGrupo = _context.Grupo.Where(x => x.id == responseRanking.idGrupo).Select(x => x.nomeGrupo).FirstOrDefault();

            int i = 1;

            foreach (UsuarioGrupo item in listaUsuarioGrupo.OrderByDescending(x => x.patrimonioAtual))
            {
                ClassificacaoUsuario classificacao = new ClassificacaoUsuario()
                {
                    idUsuario = item.idUsuario,
                    nomeUsuario = _context.Usuario.Where(x => x.id == item.idUsuario).Select(x => x.nome).FirstOrDefault(),
                    classificacao = i,
                    patrimonioInicial = item.patrimonioInicial,
                    patrimonioAtual = item.patrimonioAtual,
                    valorizacaoPerc = item.valorizacaoPerc
                };

                responseRanking.listaClassificacao.Add(classificacao);
                i++;
            }

            if (responseRanking == null)
            {
                return NotFound();
            }

            return responseRanking;
        }

        // PUT: api/UsuarioGrupo/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioGrupo(int id, UsuarioGrupo usuarioGrupo)
        {
            if (id != usuarioGrupo.id)
            {
                return BadRequest();
            }

            _context.Entry(usuarioGrupo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioGrupoExists(id))
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

        // POST: api/UsuarioGrupo
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<UsuarioGrupo>> PostUsuarioGrupo(UsuarioGrupo usuarioGrupo)
        {
            _context.UsuarioGrupo.Add(usuarioGrupo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarioGrupo", new { id = usuarioGrupo.id }, usuarioGrupo);
        }

        // DELETE: api/UsuarioGrupo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioGrupo>> DeleteUsuarioGrupo(int id)
        {
            var usuarioGrupo = await _context.UsuarioGrupo.FindAsync(id);
            if (usuarioGrupo == null)
            {
                return NotFound();
            }

            _context.UsuarioGrupo.Remove(usuarioGrupo);
            await _context.SaveChangesAsync();

            return usuarioGrupo;
        }

        private bool UsuarioGrupoExists(int id)
        {
            return _context.UsuarioGrupo.Any(e => e.id == id);
        }
    }
}
