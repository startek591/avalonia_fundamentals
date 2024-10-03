using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Avalonia_Loudness_Meter.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    [Reactive]
    public string BoldTitle { get; set; } = "AVALONIA";
    [Reactive] public string RegularTitle { get; set; } = "LOUDNESS METER";
}
