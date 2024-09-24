using ReactiveUI;
using System;

namespace BasicMvvmSample.ViewModels
{
    public class ReactiveViewModel : ReactiveObject
    {
        private string? _Name;

        public ReactiveViewModel()
        {
            this.WhenAnyValue(o => o.Name).Subscribe(o => this.RaisePropertyChanged(nameof(Greeting)));
        }

        public string? Name
        {
            get
            {
                return _Name;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _Name, value);
            }
        }

        public string Greeting
        {
            get
            {
                if (string.IsNullOrEmpty(Name))
                {
                    return "Hello World from Avalonia.Samples";
                }
                else
                {
                    return $"Hello {Name}";
                }
            }
        }
    }
}