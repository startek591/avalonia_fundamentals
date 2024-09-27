using ReactiveUI;
using System;

namespace ValidationSample.ViewModels
{
    public class ValidationUsingExceptionInsideSetterViewModel : ViewModelBase
    {
        private string? _EMail;

        public string? EMail
        {
            get { return _EMail; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(EMail), "This field is required");
                }
                else if (!value.Contains('@'))
                {
                    throw new ArgumentException(nameof(EMail), "Not a valid E-Mail-Address");
                }
                else
                {
                    this.RaiseAndSetIfChanged(ref _EMail, value);
                }
            }
        }
    }
}