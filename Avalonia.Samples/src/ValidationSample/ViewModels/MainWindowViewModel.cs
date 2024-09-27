namespace ValidationSample.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ValidationUsingDataAnnotationViewModel ValidationUsingDataAnnotationViewModel { get; } = new ValidationUsingDataAnnotationViewModel();

    public ValidationUsingINotifyDataErrorInfoViewModel ValidationUsingINotifyDataErrorInfoViewModel { get; } = new ValidationUsingINotifyDataErrorInfoViewModel();

    public ValidationUsingExceptionInsideSetterViewModel ValidationUsingExceptionInsideSetterViewModel { get; } = new ValidationUsingExceptionInsideSetterViewModel();
}
