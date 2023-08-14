using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Data;
using TodoList.Data.Dtos;
using TodoList.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace TodoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly TodoContext _context;
        private readonly IMapper _mapper;

        public TarefasController(TodoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddTarefa(CreateTarefasDto tarefaDto)
        {
            var tarefa = _mapper.Map<Tarefas>(tarefaDto);
            
            Coins coins = new Coins
            {
                Amount = tarefaDto.Amount,
                Tarefas = tarefa,
            };

            if(tarefaDto.Amount == 0 || tarefaDto.Amount == null)
            {
                return BadRequest("O valor da tarefa não pode ser nulo ou zero.");
            }

            tarefa.CreationDate = DateTime.UtcNow;

            _context.Tarefas.Add(tarefa);
            _context.Coins.Add(coins);
            _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            if(_context.Tarefas.Count() == 0)
            {
                return NotFound("Nenhuma tarefa encontrada.");
            }
            var tarefas = _context.Tarefas.Include(tarefa => tarefa.Coins); 
            var tarefasDto = _mapper.Map<IEnumerable<ReadTarefasDto>>(tarefas);
            return Ok(tarefasDto);
        }

        [HttpGet("{title}")]
        public IActionResult GetByTitle(string title)
        {
            var tarefasFiltradas = _context.Tarefas.Where(tarefa => tarefa.Title.Contains(title))
                .Include(tarefa => tarefa.Coins).ToList();
            var mapTarefas = _mapper.Map<List<ReadTarefasDto>>(tarefasFiltradas);

            if (mapTarefas.Count == 0)
            {
                return NotFound("Nenhuma tarefa encontrada com o título fornecido.");
            }

            return Ok(mapTarefas);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateTarefasDto tarefaDto)
        {
            var tarefa = _context.Tarefas.Include(tarefa => tarefa.Coins).FirstOrDefault(tarefa => tarefa.Id == id);
            if (tarefa == null)
            {
                return NotFound();
            }

            if (tarefa.Coins == null)
            {
                tarefa.Coins = new Coins();
            }

            tarefa.IsComplete = true;
            tarefa.CompletionDate = DateTime.UtcNow;
            tarefa.Coins.DateEarned = DateTime.UtcNow;

            _context.Tarefas.Update(tarefa);
            _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tarefa = _context.Tarefas.FirstOrDefault(tarefa => tarefa.Id == id);
            if(tarefa == null)
            {
                return NotFound("Nenhuma tarefa encontrada com o Id fornecido.");
            }
            _context.Tarefas.Remove(tarefa);
            _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
