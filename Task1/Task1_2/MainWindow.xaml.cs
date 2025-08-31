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

namespace Task1_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum Signals
        {
            Stop,
            Ready,
            Go
        }

        private Signals activeSignals;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void NextSignal_Click(object sender, RoutedEventArgs e)
        {
            switch (activeSignals)
            {
                case Signals.Stop:
                    Stop.Fill = Brushes.Red;
                    Ready.Fill = Brushes.Gray;
                    Go.Fill = Brushes.Gray;
                    activeSignals++;
                    break;
                    case Signals.Ready:
                    Stop.Fill = Brushes.Gray;
                    Ready.Fill = Brushes.Yellow;
                    Go.Fill = Brushes.Gray;
                    activeSignals++;
                    break;
                    case Signals.Go:
                    Stop.Fill = Brushes.Gray;
                    Ready.Fill = Brushes.Gray;
                    Go.Fill = Brushes.Green;
                    activeSignals++;
                    break;
                default:
                    activeSignals = Signals.Stop;
                    Stop.Fill = Brushes.Gray;
                    Ready.Fill = Brushes.Gray;
                    Go.Fill = Brushes.Gray;

                    break;
            }
            
        }
    }
}