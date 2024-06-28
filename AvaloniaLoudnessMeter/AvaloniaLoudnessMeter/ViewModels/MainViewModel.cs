using System.Windows.Input;
using Avalonia.Input;
using ReactiveUI;
namespace AvaloniaLoudnessMeter.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private string? _boldTitle = "AVALONIA";
    private string? _regularTitle = "LOUDNESS METER";

    private bool? _channelConfigurationListIsOpen = false;

    public MainViewModel()
    {
        ChannelConfigurationButtonPressedCommand = ReactiveCommand.Create(ChannelConfigurationButtonPressed);
    }

    public ICommand ChannelConfigurationButtonPressedCommand { get; }

    public string? BoldTitle
    {
        get => _boldTitle;
        set => this.RaiseAndSetIfChanged(ref _boldTitle, value);
    }

    public string? RegularTitle
    {
        get => _regularTitle;
        set => this.RaiseAndSetIfChanged(ref _regularTitle, value);
    }

    public bool? ChannelConfigurationListIsOpen
    {
        get => _channelConfigurationListIsOpen;
        set => this.RaiseAndSetIfChanged(ref _channelConfigurationListIsOpen, value);
    }

    private void ChannelConfigurationButtonPressed()
    {
        ChannelConfigurationListIsOpen = !ChannelConfigurationListIsOpen;
    }
}
