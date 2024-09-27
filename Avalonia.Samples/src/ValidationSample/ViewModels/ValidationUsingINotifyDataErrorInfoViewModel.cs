using ReactiveUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ValidationSample.ViewModels
{
    public class ValidationUsingINotifyDataErrorInfoViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        public ValidationUsingINotifyDataErrorInfoViewModel()
        {
            this.WhenAnyValue(x => x.EMail)
                .Subscribe(_ => Validate_EMail());

            Validate_EMail();

        }

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public bool HasErrors => errors.Count > 0;

        public IEnumerable GetErrors(string? propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                return errors.Values.SelectMany(static errors => errors);
            }
            if (this.errors.TryGetValue(propertyName!, out List<ValidationResult>? result))
            {
                return result;
            }
            return Array.Empty<ValidationResult>();
        }

        private Dictionary<string, List<ValidationResult>> errors = new Dictionary<string, List<ValidationResult>>();

        protected void ClearErrors(string? propertyName = null)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                errors.Clear();
            }
            else
            {
                errors.Remove(propertyName);
            }

            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            this.RaisePropertyChanged(nameof(HasErrors));
        }

        protected void AddError(string propertyName, string errorMessage)
        {
            if (!errors.TryGetValue(propertyName, out List<ValidationResult>? propertyErrors))
            {
                propertyErrors = new List<ValidationResult>();
                errors.Add(propertyName, propertyErrors);
            }

            propertyErrors.Add(new ValidationResult(errorMessage));

            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            this.RaisePropertyChanged(nameof(HasErrors));
        }

        private string? _EMail;

        public string? EMail
        {
            get { return _EMail; }
            set { this.RaiseAndSetIfChanged(ref _EMail, value); }
        }

        private void Validate_EMail()
        {
            ClearErrors(nameof(EMail));

            if (string.IsNullOrEmpty(EMail))
            {
                AddError(nameof(EMail), "This field is required");
            }

            if (EMail is null || !EMail.Contains('@'))
            {
                AddError(nameof(EMail), "Don't forget the '@'-sign");
            }
        }

    }
}