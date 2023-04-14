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
        private ObservableCollection<TodoItem> unfiltereditems;
        private bool isChecked = false;

        public ReactiveCommand<Unit, Unit> ShowUncompleted { get; }

        public TodoListViewModel(IEnumerable<TodoItem> items)
        {
            Items = new ObservableCollection<TodoItem>(items);
            unfiltereditems = Items;
            ShowUncompleted = ReactiveCommand.Create(ToggleFilteredItems);

        }

        public void ToggleFilteredItems()
        {
            if (isChecked)
            {
                Items = unfiltereditems;
                isChecked = !isChecked;
            }
            else
            {
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
                isChecked = !isChecked;
            }
        }

        public ObservableCollection<TodoItem> Items 
        { 
            get => items;
            set => this.RaiseAndSetIfChanged(ref items, value);
        }
    }
}