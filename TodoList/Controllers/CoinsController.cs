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
    public class CoinsController : ControllerBase
    {
        public List<Tarefas> tarefas = new List<Tarefas>();
        private readonly TodoContext _context;
        private readonly IMapper _mapper;

        public CoinsController(TodoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaMoeda([FromBody] CreateCoinsDto coinDto)
        {
            Coins coins = _mapper.Map<Coins>(coinDto);
            foreach (var tarefa in tarefas)
            {
                if (tarefa.Id == coinDto.IdTarefa)
                {
                    tarefa.Coins.Add(coins);
                    _context.SaveChanges();
                }
            }
            return CreatedAtAction(nameof(GetById), new { id = coins.Id }, coins);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var coin = _context.Coins.FirstOrDefault(t => t.Id == id);
            if(coin == null)
            {
                return NotFound();
            }
            var coinDto = _mapper.Map<ReadCoinDto>(coin);
            return Ok(coinDto);
        }
    }
}
