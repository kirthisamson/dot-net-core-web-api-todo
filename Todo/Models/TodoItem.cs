using System;
namespace Todo.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public Boolean IsCompleted { get; set; }
    }
}
