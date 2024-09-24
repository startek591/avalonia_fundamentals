namespace BasicMvvmSample.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ReactiveViewModel ReactiveViewModel { get; } = new ReactiveViewModel();
}
