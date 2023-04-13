using System.Reactive;
using AvaloniaApplication.Models;
using ReactiveUI;

namespace AvaloniaApplication.ViewModels
{
    public class AddItemViewModel : ViewModelBase
    {
        string description;

        public AddItemViewModel()
        {
            // A stream of bool values which will change depending on two qualifies
            var okEnabled = this.WhenAnyValue(
                x => x.Description,
                x => !string.IsNullOrWhiteSpace(x)
            );

            // The second param is the enabled state of the button,
            // Basically its the condition on which the button can execute
            Ok = ReactiveCommand.Create(
                () => new TodoItem { Description = Description},
                okEnabled
            );

            Cancel = ReactiveCommand.Create(() => {  });
        }

        public string Description 
        { 
            get => description; 
            // Whenever the description is changed, it raises a notification for the UI
            set => this.RaiseAndSetIfChanged(ref description, value); 
        }

        // Reactive command is an observable itself
        // Unit is the void of reactiveUI
        // This takes in void and produces a todoitem
        public ReactiveCommand<Unit, TodoItem> Ok { get; }
        public ReactiveCommand<Unit, Unit> Cancel { get; }
    }   
}