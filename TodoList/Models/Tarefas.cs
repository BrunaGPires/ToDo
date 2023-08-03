using System.ComponentModel.DataAnnotations;

namespace TodoList.Models
{
    public class Tarefas
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? CompletionDate { get; set; }
    }
}
