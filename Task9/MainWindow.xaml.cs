using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Stack<Brush> _colorHistory = new Stack<Brush>();
        private Brush _currentColor;
        private Brush _previousColor;

        public Brush CurrentColor
        {
            get => _currentColor;
            set
            {
                _previousColor = _currentColor;
                _currentColor = value;

                if (_colorHistory.Count == 0 || !_colorHistory.Peek().Equals(value))
                {
                    _colorHistory.Push(value);
                }
                Dock.Background = _currentColor;
                UpdatePreviousColorIndicator();
                CommandManager.InvalidateRequerySuggested(); 
                OnPropertyChanged(nameof(CurrentColor));
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            CurrentColor = Brushes.White; 
        }

        private void ChangeColorExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var random = new Random();
            CurrentColor = new SolidColorBrush(Color.FromRgb(
                (byte)random.Next(256),
                (byte)random.Next(256),
                (byte)random.Next(256)));
        }

        private void UndoExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (_colorHistory.Count > 1)
            {
                _colorHistory.Pop(); 
                CurrentColor = _colorHistory.Peek(); 
            }
        }

        private void UndoCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _colorHistory.Count > 1; 
        }
        private void UpdatePreviousColorIndicator()
        {
            if (PreviousColorIndicator != null && _previousColor != null)
            {
                PreviousColorIndicator.Background = _previousColor;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
