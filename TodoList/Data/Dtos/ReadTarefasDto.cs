namespace TodoList.Data.Dtos
{
    public class ReadTarefasDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public bool IsComplete { get; set; }

        public ReadCoinDto Coins { get; set; }
    }
}
