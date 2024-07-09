using CrudAngularAndAspNet.Server.Data;
using CrudAngularAndAspNet.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudAngularAndAspNet.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoasController : ControllerBase
    {
        private readonly Contexto _contexto;

        public PessoasController(Contexto contexto)
        {
            _contexto = contexto;
        }

        // GET: api/pessoas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>> PegarTodosAsync()
        {
            return await _contexto.pessoas.ToListAsync();
        }

        // GET: api/pessoas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> PegarPorIdAsync(int id)
        {
            var pessoa = await _contexto.pessoas.FindAsync(id);

            if (pessoa == null)
            {
                return NotFound();
            }

            return pessoa;
        }

        // PUT: api/pessoas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarAsync(int id, Pessoa pessoa)
        {
            if (id != pessoa.PessoaId)
            {
                return BadRequest();
            }

            //_contexto.pessoas.Update(pessoa);
            _contexto.Entry(pessoa).State = EntityState.Modified;

            try
            {
                await _contexto.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PessoaExists(id))
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

        // POST: api/pessoas
        [HttpPost]
        public async Task<ActionResult<Pessoa>> CriarAsync(Pessoa pessoa)
        {
            _contexto.pessoas.Add(pessoa);
            await _contexto.SaveChangesAsync();

            return CreatedAtAction("PegarPorId", new { id = pessoa.PessoaId }, pessoa);
        }

        // DELETE: api/pessoas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarAsync(int id)
        {
            var pessoa = await _contexto.pessoas.FindAsync(id);
            if (pessoa == null)
            {
                return NotFound();
            }

            _contexto.pessoas.Remove(pessoa);
            await _contexto.SaveChangesAsync();

            return NoContent();
        }

        private bool PessoaExists(int id)
        {
            return _contexto.pessoas.Any(e => e.PessoaId == id);
        }
    }
}