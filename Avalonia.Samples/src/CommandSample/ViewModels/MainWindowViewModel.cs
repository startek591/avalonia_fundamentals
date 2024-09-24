using ReactiveUI;
using System.Collections.ObjectModel;
using System;
using System.Windows.Input;

namespace CommandSample.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        OpenThePodBayDoorsDirectCommand = ReactiveCommand.Create(OpenThePodBayDoors);
    }

    public ICommand OpenThePodBayDoorsDirectCommand { get; }

    private void OpenThePodBayDoors()
    {
        ConversationLog.Clear();
        AddToConvo("I'm sorry, Dave, I'm afraid I can't do that.");

    }

    public ObservableCollection<string> ConversationLog { get; } = new ObservableCollection<string>();

    private void AddToConvo(string content)
    {
        ConversationLog.Add(content);
    }
}
