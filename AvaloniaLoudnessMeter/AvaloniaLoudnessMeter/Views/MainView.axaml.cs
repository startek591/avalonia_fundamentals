using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Controls.Primitives;
using AvaloniaLoudnessMeter.ViewModels;
using System;

namespace AvaloniaLoudnessMeter.Views;

public partial class MainView : UserControl
{
    private Control mChannelConfigPopup;
    private Control mChannelConfigButton;

    private Control mMainGrid;
    public MainView()
    {
        InitializeComponent();
        mChannelConfigButton = this.FindControl<Control>("ChannelConfigurationButton") ?? throw new Exception("Cannot find Channel Configuration Button by name");
        mChannelConfigPopup = this.FindControl<Control>("ChannelConfigurationPopup") ?? throw new Exception("Cannot find Channel Configuration Popup by name");
        mMainGrid = this.FindControl<Control>("MainGrid") ?? throw new Exception("Cannot find Main Grid by name");

        mChannelConfigButton.PointerPressed += InputElement_OnPointerPressed;
        // Listen to changes in popup visibility to adjust its position
        mChannelConfigPopup.PropertyChanged += (sender, args) =>
        {
            if (args.Property.Name == nameof(IsVisible) && mChannelConfigPopup.IsVisible)
            {
                this.UpdatePopupPosition();
            }
        };

    }

    private void UpdatePopupPosition()
    {
        var position = mChannelConfigButton.TranslatePoint(new Point(), mMainGrid)
            ?? throw new Exception("Cannot get TranslatePoint from Configuration Button");

        mChannelConfigPopup.Margin = new Thickness(
            position.X,
            0,
            0,
            mMainGrid.Bounds.Height - position.Y - mChannelConfigButton.Bounds.Height);
    }


    private void InputElement_OnPointerPressed(object sender, PointerPressedEventArgs e) => ((MainViewModel)DataContext).ChannelConfigurationButtonPressedCommand.Execute(null);
}