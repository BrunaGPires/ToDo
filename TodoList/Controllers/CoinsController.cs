using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
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
        public IActionResult AddCoinInTarefas(CreateCoinsDto coindto)
        {
            var tarefa = _context.Tarefas.FirstOrDefault(t => t.Id == coindto.IdTarefa);

            Coins coins = new Coins
            {
                Amount = coindto.Amount,
                Tarefas = tarefa
            };

            _context.Coins.Add(coins);
            _context.SaveChanges();

            return Ok();
        }
    }
}
