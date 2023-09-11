namespace todo_api.Models
{
    public class TodoItem
    {
        public int Id { get; set; }

        public string Content { get; set; } 

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool Completed { get; set; }   

    }
}
