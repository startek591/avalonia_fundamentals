using ReactiveUI;
using System.Collections.ObjectModel;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CommandSample.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        OpenThePodBayDoorsDirectCommand = ReactiveCommand.Create(OpenThePodBayDoors);

        IObservable<bool> canExecuteFellowRobotCommand =
            this.WhenAnyValue(vm => vm.RobotName, (name) => !string.IsNullOrEmpty(name));

        OpenThePodBayDoorsFellowRobotCommand =
            ReactiveCommand.Create<string?>(name => OpenThePodBayDoorsFellowRobot(name), canExecuteFellowRobotCommand);

        OpenThePodBayDoorsAsyncCommand = ReactiveCommand.CreateFromTask(OpenThePodBayDoorsAsync);

    }

    public ICommand OpenThePodBayDoorsDirectCommand { get; }

    private void OpenThePodBayDoors()
    {
        ConversationLog.Clear();
        AddToConvo("I'm sorry, Dave, I'm afraid I can't do that.");
    }

    public ICommand OpenThePodBayDoorsFellowRobotCommand { get; }

    private void OpenThePodBayDoorsFellowRobot(string? robotName)
    {
        ConversationLog.Clear();
        AddToConvo($"Hello {robotName}, the Pod Bay is open :-)");
    }

    private string? _RobotName;

    public string? RobotName
    {
        get => _RobotName;
        set => this.RaiseAndSetIfChanged(ref _RobotName, value);
    }

    public ICommand OpenThePodBayDoorsAsyncCommand { get; }

    private async Task OpenThePodBayDoorsAsync()
    {
        ConversationLog.Clear();
        AddToConvo("Preparing to open the Pod Bay...");

        await Task.Delay(1000);

        AddToConvo("Depressurizing Airlock....");
        await Task.Delay(2000);

        AddToConvo("Retracting blast doors");
        await Task.Delay(2000);

        AddToConvo("Pod Bay is open to space!");
    }


    public ObservableCollection<string> ConversationLog { get; } = new ObservableCollection<string>();

    private void AddToConvo(string content)
    {
        ConversationLog.Add(content);
    }
}
