using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApiProdutos.Data;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : Controller
    {
        private readonly AppDbContext _context;

        public FuncionariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Listagem de todos os funcionarios
        [HttpGet]
        [SwaggerOperation(Summary = "Permite listar todos os funcionários.")]
        public async Task<ActionResult<IEnumerable<Funcionario>>> ListFuncionarios()
        {
            return await _context.Funcionarios.ToListAsync();
        }

        // GET: Busca de somente um funcionario
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Busca um funcionário de acordo com o ID.")]
        public async Task<ActionResult<Funcionario>> GetFuncionario(int id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);

            if (funcionario == null)
                return NotFound("Não existe nenhum funcionario com essa identificação");

            return Ok(funcionario);
        }

        // PUT: Atualizar informação de um funcionario
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza as informações do funcionário escolhido.")]
        public async Task<IActionResult> PutFuncionario(int id, Funcionario funcionario)
        {
            if (id != funcionario.funcionarioId)
                return BadRequest("Identificador do funcionario não condiz com sua descrição");

            _context.Entry(funcionario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuncionarioExists(id))
                    return NotFound("Funcionario com essa descrição não existe.");
                else
                    throw;
            }

            return Ok();
        }

        // POST: Criar um novo funcionario
        [HttpPost]
        [SwaggerOperation(Summary = "Cria um novo funcionário com as informações inseridas.")]
        public async Task<ActionResult<Funcionario>> CreateFuncionario(Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFuncionario", new { id = funcionario.funcionarioId }, funcionario);
        }

        // DELETE: Deleta um funcionario
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deleta um funcionário de acordo com o ID.")]
        public async Task<IActionResult> DeleteFuncionario(int id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);

            if (funcionario == null)
                return NotFound("Não tem nenhum funcionario com essa identificação");

            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Verifica se o funcionario existe
        private bool FuncionarioExists(int id)
        {
            return _context.Funcionarios.Any(e => e.funcionarioId == id);
        }
    }
}
