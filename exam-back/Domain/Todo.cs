namespace Domain
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = default!;
        public DateTime CreatedDate { get; set; }
        public int Sort { get;set ; }
        public Guid CategoryId { get; set; }
        public TodoCategory Category { get; set; } = default!;
        public Guid PriorityId { get; set; }
        public TodoPriority Priority { get; set; } = default!;



    }
}
