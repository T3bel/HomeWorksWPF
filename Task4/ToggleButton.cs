using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Task4
{
    public class ToggleButton : Button
    {
        public static readonly DependencyProperty IsToggledProperty = DependencyProperty.Register(
            nameof(IsToggled),
            typeof(bool),
            typeof(ToggleButton),
            new FrameworkPropertyMetadata(
                defaultValue: false,
                flags: FrameworkPropertyMetadataOptions.AffectsRender,
                propertyChangedCallback: OnIsToggledPropertyChanged)
            );

        public ToggleButton()
        {
            InitializeButton();
            Click += OnToggleButtonClick;
        }

        private void InitializeButton()
        {
            UpdateButtonAppearance();
            MinWidth = 80;
            MinHeight = 30;
            Padding = new Thickness(10, 5, 10, 5);

            OverridesDefaultStyle = true;
        }

        private void OnToggleButtonClick(object sender, RoutedEventArgs e)
        {
            IsToggled = !IsToggled;
        }

        private static void OnIsToggledPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ToggleButton toggleButton)
            {
                toggleButton.UpdateButtonAppearance();
            }
        }

        private void UpdateButtonAppearance()
        {
            Content = IsToggled ? "ВКЛ" : "ВЫКЛ";
            Background = IsToggled ?
                new SolidColorBrush(Colors.LimeGreen) :
                new SolidColorBrush(Colors.Tomato);

            Foreground = new SolidColorBrush(Colors.White);
            FontWeight = FontWeights.Bold;
            BorderBrush = new SolidColorBrush(Colors.DarkGray);
        }

        public bool IsToggled
        {
            get => (bool)GetValue(IsToggledProperty);
            set => SetValue(IsToggledProperty, value);
        }
    }
}