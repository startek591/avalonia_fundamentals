using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace Avalonia_Loudness_Meter;

public class LargeLabelControl : TemplatedControl
{
    public static readonly StyledProperty<string> LargeTextProperty = AvaloniaProperty.Register<LargeLabelControl, string>("Large Text", "LARGE TEXT");

    public string LargeText
    {
        get => GetValue(LargeTextProperty);
        set => SetValue(LargeTextProperty, value);
    }

    public static readonly StyledProperty<string> SmallTextProperty = AvaloniaProperty.Register<LargeLabelControl, string>("SmallText", "SMALL TEXT");

    public string SmallText
    {
        get => GetValue(SmallTextProperty);
        set => SetValue(SmallTextProperty, value);
    }
}