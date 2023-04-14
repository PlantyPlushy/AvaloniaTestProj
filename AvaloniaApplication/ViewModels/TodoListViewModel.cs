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
        public TodoListViewModel(IEnumerable<TodoItem> items)
        {
            Items = new ObservableCollection<TodoItem>(items);

            ShowUncompleted = ReactiveCommand.Create(() => 
            {
                ObservableCollection<TodoItem> filteredItems = new();
                foreach (var item in Items)
                {
                    if (!item.IsChecked)
                    {
                        filteredItems.Add(new TodoItem { Description = item.Description });
                    }
                }
                Items = filteredItems;
            });
        }

        public ObservableCollection<TodoItem> Items 
        { 
            get => items;
            set => this.RaiseAndSetIfChanged(ref items, value);
        }
        public ReactiveCommand<Unit, Unit> ShowUncompleted { get; }
    }
}