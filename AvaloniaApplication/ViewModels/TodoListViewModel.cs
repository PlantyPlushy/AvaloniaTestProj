using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using AvaloniaApplication.Models;
using ReactiveUI;

namespace AvaloniaApplication.ViewModels
{
    // Represents a collection of items that can update
    public class TodoListViewModel : ViewModelBase
    {
        ObservableCollection<TodoItem> items;
        ObservableCollection<TodoItem> unfilteredItems;
        private bool isChecked = true;

        public TodoListViewModel(IEnumerable<TodoItem> items)
        {
            Items = new ObservableCollection<TodoItem>(items);
            unfilteredItems = new ObservableCollection<TodoItem>();

            //ShowUncompleted = ReactiveCommand.Create(ToggleFilteredItems);

        }

        public void ShowUncompleted()
        {
            // Save the unfiltered list to toggle later
            unfilteredItems.Clear();
            foreach (var item in Items)
            {
                unfilteredItems.Add(new TodoItem { Description = item.Description, IsChecked = item.IsChecked });
            }

            // Filter and set the Items event to the filtered items
            ObservableCollection<TodoItem> filteredItems = new();
            foreach (var item in Items)
            {
                if (!item.IsChecked)
                {
                    filteredItems.Add(new TodoItem { Description = item.Description });
                }
            }
            Items = filteredItems;
        }

        public ObservableCollection<TodoItem> Items 
        { 
            get => items;
            set => this.RaiseAndSetIfChanged(ref items, value);
        }
    }
}