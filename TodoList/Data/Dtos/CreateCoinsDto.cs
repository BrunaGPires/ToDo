using System.ComponentModel.DataAnnotations;

namespace TodoList.Data.Dtos
{
    public class CreateCoinsDto
    {
        [Required]
        public int Amount { get; set; }

        public int IdTarefa { get; set; }
    }
}
