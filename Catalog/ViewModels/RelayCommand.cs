using System;
using System.Windows.Input;

namespace Catalog.ViewModels;

public class RelayCommand : ICommand
{
    private Action action;

    public RelayCommand(Action action)
    {
        this.action = action;
    }

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        action();
    }

    public event EventHandler? CanExecuteChanged;
}