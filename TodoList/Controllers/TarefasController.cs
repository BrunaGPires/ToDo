using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Data;
using TodoList.Data.Dtos;
using TodoList.Models;

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
        public IActionResult Post([FromBody] CreateTarefasDto tarefaDto)
        {
            Tarefas tarefas = _mapper.Map<Tarefas>(tarefaDto);
            _context.Tarefas.Add(tarefas);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {id = tarefas.Id}, tarefas);
        }

        [HttpGet]
        public IEnumerable<ReadTarefasDto> Get([FromQuery] string? tituloTarefa = null)
        {
            if(tituloTarefa == null)
            {
                return _context.Tarefas.ToList().Select(t => _mapper.Map<ReadTarefasDto>(t));
            }
            return _context.Tarefas.Where(t => t.Title.Contains(tituloTarefa)).ToList().Select(t => _mapper.Map<ReadTarefasDto>(t));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var tarefa = _context.Tarefas.FirstOrDefault(t => t.Id == id);
            if(tarefa == null)
            {
                return NotFound();
            }
            var tarefaDto = _mapper.Map<ReadTarefasDto>(tarefa);
            return Ok(tarefaDto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateTarefasDto tarefaDto)
        {
            var tarefa = _context.Tarefas.FirstOrDefault(t => t.Id == id);
            if(tarefa == null)
            {
                return NotFound();
            }
            _mapper.Map(tarefaDto, tarefa);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var tarefa = _context.Tarefas.FirstOrDefault(t => t.Id == id);
            if(tarefa == null)
            {
                return NotFound();
            }
            _context.Tarefas.Remove(tarefa);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
