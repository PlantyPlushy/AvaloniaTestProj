using System.Collections.Generic;
using System.Collections.ObjectModel;
using AvaloniaApplication.Models;

namespace AvaloniaApplication.ViewModels
{
    // Represents a collection of items that can update
    public class TodoListViewModel : ViewModelBase
    {
        public TodoListViewModel(IEnumerable<TodoItem> items)
        {
            Items = new ObservableCollection<TodoItem>(items);
        }

        public ObservableCollection<TodoItem> Items { get; }
    }
}