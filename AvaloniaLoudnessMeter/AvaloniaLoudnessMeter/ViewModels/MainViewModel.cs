using ReactiveUI;
namespace AvaloniaLoudnessMeter.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private string? _boldTitle = "AVALONIA";
    private string? _regularTitle = "LOUDNESS METER";

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

}
