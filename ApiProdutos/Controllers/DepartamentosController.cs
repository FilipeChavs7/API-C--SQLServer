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
    public class DepartamentosController : Controller
    {
        private readonly AppDbContext _context;

        public DepartamentosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Listagem de todos os departamentos
        [HttpGet]
        [SwaggerOperation(Summary = "Permite listar todos os departamentos.")]
        public async Task<ActionResult<IEnumerable<Departamento>>> ListDepartamentos()
        {
            return await _context.Departamentos.ToListAsync();
        }

        // GET: Busca de somente um departamento
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Permite buscar um departamento existente.")]
        public async Task<ActionResult<Departamento>> GetDepartamento(int id)
        {
            var departamento = await _context.Departamentos.FindAsync(id);

            if (departamento == null)
                return NotFound("Não existe nenhum departamento com essa identificação");

            return Ok(departamento);
        }

        // PUT: Atualizar informação de um departamento
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza os dados de um departamento.")]
        public async Task<IActionResult> PutDepartamento(int id, Departamento departamento)
        {
            if (id != departamento.departamentoId)
                return BadRequest("Identificador do departamento não condiz com sua descrição");

            _context.Entry(departamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartamentoExists(id))
                    return NotFound("Departamento com essa descrição não existe.");
                else
                    throw;
            }

            return Ok();
        }

        // POST: Criar um novo departamento
        [HttpPost]
        [SwaggerOperation(Summary = "Cria um novo departamento com os dados inseridos.")]
        public async Task<ActionResult<Departamento>> CreateDepartamento(Departamento departamento)
        {
            _context.Departamentos.Add(departamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartamento", new { id = departamento.departamentoId }, departamento);
        }

        // Verificação para ver se o departamento existe
        private bool DepartamentoExists(int id)
        {
            return _context.Departamentos.Any(e => e.departamentoId == id);
        }
    }
}
