namespace AvaloniaApplication.Models
{
    // Represents how data should be structured coming from the database
    public class TodoItem 
    {
        public string Description { get; set; }
        public bool IsChecked { get; set; }
    }
}