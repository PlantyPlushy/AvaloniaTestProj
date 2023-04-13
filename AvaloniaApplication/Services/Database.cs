using System.Collections.Generic;
using AvaloniaApplication.Models;

namespace AvaloniaApplication.Services
{
    // Represents the database 
    // For now, data is supplied through an array
    public class Database
    {
        public IEnumerable<TodoItem> GetItems() => new[]
        {
            new TodoItem { Description = "Feed the worm" },
            new TodoItem { Description = "Buy tapeworm food" },
            new TodoItem { Description = "Learn the dark arts", IsChecked = true },
        };
    }
}