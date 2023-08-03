using System.ComponentModel.DataAnnotations;

namespace TodoList.Data.Dtos
{
    public class CreateTarefasDto
    {
        [Required(ErrorMessage = "O titulo da tarefa é obrigatorio.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "A descrição da tarefa é obrigatoria.")]
        public string Description { get; set; }
    }
}
