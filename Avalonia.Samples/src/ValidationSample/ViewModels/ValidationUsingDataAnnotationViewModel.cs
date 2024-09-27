using ReactiveUI;
using System.ComponentModel.DataAnnotations;

namespace ValidationSample.ViewModels
{
    public class ValidationUsingDataAnnotationViewModel : ViewModelBase
    {
        private string? _EMail;

        [Required]
        [EmailAddress]
        public string? EMail
        {
            get { return _EMail; }
            set { this.RaiseAndSetIfChanged(ref _EMail, value); }
        }
    }
}