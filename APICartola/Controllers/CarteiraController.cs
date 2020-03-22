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
    public class CarteiraController : ControllerBase
    {
        private readonly CartolaContext _context;

        public CarteiraController(CartolaContext context)
        {
            _context = context;
        }

        // GET: api/Carteiras
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Carteira>>> GetCarteira()
        //{
        //    return await _context.Carteira.ToListAsync();
        //}

        //// GET: api/Carteiras/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Carteira>> GetCarteira(int id)
        //{
        //    var carteira = await _context.Carteira.FindAsync(id);

        //    if (carteira == null)
        //    {
        //        return NotFound();
        //    }

        //    return carteira;
        //}

        [HttpGet("{idUsuario}/{semana}")]
        public ActionResult<responseMinhaCarteira> GetCarteiraUsuario(int idUsuario, int semana)
        {
            Random random = new Random();
            decimal valorTotalCusto = 0;

            var carteira = _context.Carteira.Where(x => x.idUsuario == idUsuario && x.semana == semana).FirstOrDefault();

            responseMinhaCarteira minhaCarteira = new responseMinhaCarteira();
            minhaCarteira.idCarteira = carteira.id;
            minhaCarteira.semana = carteira.semana;

            DetalheCarteira detalheCarteira = new DetalheCarteira()
            {
                idAcao = carteira.idAcao1,
                codAcao = _context.Acao.Where(x => x.id == carteira.idAcao1).Select(x => x.codAcao).First(),
                qtdAcao = carteira.qtdAcao1,
                cotacaoInicial = _context.Cotacao.Where(x => x.idAcao == carteira.idAcao1 && x.semana == carteira.semana).Select(x => x.cotacao).FirstOrDefault()
            };

            detalheCarteira.percentual = Math.Round(((Decimal)random.Next(0, 500) / 100), 2);
            detalheCarteira.custo = detalheCarteira.qtdAcao * detalheCarteira.cotacaoInicial;
            detalheCarteira.cotacaoAtual = Math.Round(detalheCarteira.cotacaoInicial * (((decimal)detalheCarteira.percentual / 100) + 1), 2);
            detalheCarteira.valorTotal = detalheCarteira.qtdAcao * detalheCarteira.cotacaoAtual;
            minhaCarteira.listaAcoes.Add(detalheCarteira);
            minhaCarteira.ValorTotal += detalheCarteira.valorTotal;
            valorTotalCusto += detalheCarteira.custo;

            detalheCarteira = new DetalheCarteira()
            {
                idAcao = carteira.idAcao2,
                codAcao = _context.Acao.Where(x => x.id == carteira.idAcao2).Select(x => x.codAcao).First(),
                qtdAcao = carteira.qtdAcao2,
                cotacaoInicial = _context.Cotacao.Where(x => x.idAcao == carteira.idAcao2 && x.semana == carteira.semana).Select(x => x.cotacao).FirstOrDefault()
            };

            detalheCarteira.percentual = Math.Round(((Decimal)random.Next(0, 500) / 100), 2);
            detalheCarteira.custo = detalheCarteira.qtdAcao * detalheCarteira.cotacaoInicial;
            detalheCarteira.cotacaoAtual = Math.Round(detalheCarteira.cotacaoInicial * (((decimal)detalheCarteira.percentual / 100) + 1), 2);
            detalheCarteira.valorTotal = detalheCarteira.qtdAcao * detalheCarteira.cotacaoAtual;
            minhaCarteira.listaAcoes.Add(detalheCarteira);
            minhaCarteira.ValorTotal += detalheCarteira.valorTotal;
            valorTotalCusto += detalheCarteira.custo;

            detalheCarteira = new DetalheCarteira()
            {
                idAcao = carteira.idAcao3,
                codAcao = _context.Acao.Where(x => x.id == carteira.idAcao3).Select(x => x.codAcao).First(),
                qtdAcao = carteira.qtdAcao3,
                cotacaoInicial = _context.Cotacao.Where(x => x.idAcao == carteira.idAcao3 && x.semana == carteira.semana).Select(x => x.cotacao).FirstOrDefault()
            };

            detalheCarteira.percentual = Math.Round(((Decimal)random.Next(0, 500) / 100), 2);
            detalheCarteira.custo = detalheCarteira.qtdAcao * detalheCarteira.cotacaoInicial;
            detalheCarteira.cotacaoAtual = Math.Round(detalheCarteira.cotacaoInicial * (((decimal)detalheCarteira.percentual / 100) + 1), 2);
            detalheCarteira.valorTotal = detalheCarteira.qtdAcao * detalheCarteira.cotacaoAtual;
            minhaCarteira.listaAcoes.Add(detalheCarteira);
            minhaCarteira.ValorTotal += detalheCarteira.valorTotal;
            valorTotalCusto += detalheCarteira.custo;


            detalheCarteira = new DetalheCarteira()
            {
                idAcao = carteira.idAcao4,
                codAcao = _context.Acao.Where(x => x.id == carteira.idAcao4).Select(x => x.codAcao).First(),
                qtdAcao = carteira.qtdAcao4,
                cotacaoInicial = _context.Cotacao.Where(x => x.idAcao == carteira.idAcao4 && x.semana == carteira.semana).Select(x => x.cotacao).FirstOrDefault()
            };

            detalheCarteira.percentual = Math.Round(((Decimal)random.Next(0, 500) / 100), 2);
            detalheCarteira.custo = detalheCarteira.qtdAcao * detalheCarteira.cotacaoInicial;
            detalheCarteira.cotacaoAtual = Math.Round(detalheCarteira.cotacaoInicial * (((decimal)detalheCarteira.percentual / 100) + 1), 2);
            detalheCarteira.valorTotal = detalheCarteira.qtdAcao * detalheCarteira.cotacaoAtual;
            minhaCarteira.listaAcoes.Add(detalheCarteira);
            minhaCarteira.ValorTotal += detalheCarteira.valorTotal;
            valorTotalCusto += detalheCarteira.custo;


            detalheCarteira = new DetalheCarteira()
            {
                idAcao = carteira.idAcao5,
                codAcao = _context.Acao.Where(x => x.id == carteira.idAcao5).Select(x => x.codAcao).First(),
                qtdAcao = carteira.qtdAcao5,
                cotacaoInicial = _context.Cotacao.Where(x => x.idAcao == carteira.idAcao5 && x.semana == carteira.semana).Select(x => x.cotacao).FirstOrDefault()
            };

            detalheCarteira.percentual = Math.Round(((Decimal)random.Next(0, 500) / 100),2);
            detalheCarteira.custo = detalheCarteira.qtdAcao * detalheCarteira.cotacaoInicial;
            detalheCarteira.cotacaoAtual = Math.Round(detalheCarteira.cotacaoInicial * (((decimal)detalheCarteira.percentual / 100) + 1),2);
            detalheCarteira.valorTotal = detalheCarteira.qtdAcao * detalheCarteira.cotacaoAtual;
            minhaCarteira.listaAcoes.Add(detalheCarteira);
            minhaCarteira.ValorTotal += detalheCarteira.valorTotal;
            valorTotalCusto += detalheCarteira.custo;

            minhaCarteira.ValorTotal = Math.Round(minhaCarteira.ValorTotal, 2);
            minhaCarteira.PercTotal = Math.Round(((minhaCarteira.ValorTotal / valorTotalCusto) -1 )*100,2);
            
            if (carteira == null)
            {
                return NotFound();
            }

            return minhaCarteira;
        }

        [HttpGet("GetCarteiraGrupo/{idGrupo}/{semana}")]
        public ActionResult<List<Carteira>> GetCarteiraGrupo(int idGrupo, int semana)
        {
            List<int> usuarios = _context.UsuarioGrupo.Where(x => x.idGrupo == idGrupo).Select(x => x.idUsuario).ToList();
            var carteira = _context.Carteira.Where(x => usuarios.Contains(x.idUsuario) && x.semana == semana).ToList();

            if (carteira == null)
            {
                return NotFound();
            }

            return carteira;
        }

        //// PUT: api/Carteiras/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCarteira(int id, Carteira carteira)
        //{
        //    if (id != carteira.id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(carteira).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CarteiraExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Carteiras
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPost]
        //public async Task<ActionResult<Carteira>> PostCarteira(Carteira carteira)
        //{
        //    _context.Carteira.Add(carteira);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetCarteira", new { id = carteira.id }, carteira);
        //}

        //// DELETE: api/Carteiras/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Carteira>> DeleteCarteira(int id)
        //{
        //    var carteira = await _context.Carteira.FindAsync(id);
        //    if (carteira == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Carteira.Remove(carteira);
        //    await _context.SaveChangesAsync();

        //    return carteira;
        //}

        //private bool CarteiraExists(int id)
        //{
        //    return _context.Carteira.Any(e => e.id == id);
        //}
    }
}
