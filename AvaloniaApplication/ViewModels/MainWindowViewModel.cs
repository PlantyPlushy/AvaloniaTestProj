using System;
using System.Reactive.Linq;
using AvaloniaApplication.Models;
using AvaloniaApplication.Services;
using ReactiveUI;

namespace AvaloniaApplication.ViewModels
{
    // The main window
    //\ TodoListViewModel is a child of the main window so the main window supplies it list items
    public class MainWindowViewModel : ViewModelBase
    {
        // This is like a switch which will go through our different views
        // The same behavior can be done with extra windows
        ViewModelBase content;
        public MainWindowViewModel(Database db)
        {
            Content = List = new TodoListViewModel(db.GetItems());
        }

        public TodoListViewModel List { get; }
        public ViewModelBase Content 
        { 
            get => content; 
            // When the content changes value,Its needed to alert the UI that a change happened
            private set => this.RaiseAndSetIfChanged(ref content, value); 
        }

        public void AddItem()
        {
            var vm = new AddItemViewModel();

            // Merges these two buttons to have the same behaviour aka returns to itemviewmodel
            // It changes the return type of cancel to be a null so they both return something
            Observable.Merge(vm.Ok, vm.Cancel.Select(_ => (TodoItem)null))
                .Take(1)
                .Subscribe(model =>
                {
                    if (model is not null)
                    {
                        List.Items.Add(model);
                    }

                    Content = List;
                });

            Content = vm;
        }
    }
}