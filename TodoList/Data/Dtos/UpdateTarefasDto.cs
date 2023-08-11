﻿using System.ComponentModel.DataAnnotations;
using TodoList.Models;

namespace TodoList.Data.Dtos
{
    public class UpdateTarefasDto
    {
        [Required(ErrorMessage = "O titulo da tarefa é obrigatorio.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "A descrição da tarefa é obrigatoria.")]
        public string Description { get; set; }
        public bool IsComplete { get; set; }
    }
}
