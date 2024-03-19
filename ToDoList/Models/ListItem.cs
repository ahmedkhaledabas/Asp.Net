﻿namespace ToDoList.Models
{
    public class ListItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime DeadLine { get; set; } 
    }
}
