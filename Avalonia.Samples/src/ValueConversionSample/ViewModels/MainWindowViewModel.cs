using ReactiveUI;

namespace ValueConversionSample.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private decimal? _Number1 = 2;

    public decimal? Number1
    {
        get { return _Number1; }
        set { this.RaiseAndSetIfChanged(ref _Number1, value); }
    }

    private decimal? _Number2 = 3;

    public decimal? Number2
    {
        get { return _Number2; }
        set { this.RaiseAndSetIfChanged(ref _Number2, value); }
    }

    private string _Operator = "+";

    public string Operator
    {
        get { return _Operator; }
        set { this.RaiseAndSetIfChanged(ref _Operator, value); }
    }

    public string[] AvailableMathOperators { get; } = new string[]
    {
        "+", "-", "*", "/"
    };
}
