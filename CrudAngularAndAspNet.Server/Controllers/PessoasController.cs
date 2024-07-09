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

        //pegar todos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>> PegarTodosAsync()
        {
            return await _contexto.pessoas.ToListAsync();
        }


        //pegar por id
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

        //update 
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarAsync(int id, Pessoa pessoa)
        {
            if (id != pessoa.PessoaId)
            {
                return BadRequest();
            }

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

        //adicionar pessoa
        [HttpPost]
        public async Task<ActionResult<Pessoa>> CriarAsync(Pessoa pessoa)
        {
            _contexto.pessoas.Add(pessoa);
            await _contexto.SaveChangesAsync();

            return CreatedAtAction("PegarPorId", new { id = pessoa.PessoaId }, pessoa);
        }

        //deletar pessoa
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