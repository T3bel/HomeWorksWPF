using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task1_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SibacaButton_MouseEnter(object sender, MouseEventArgs e)
        {
            var random = new Random();
            if (sender is Ellipse ellipse)
            {
                var grad = new LinearGradientBrush();

                Canvas.SetLeft(ellipse, random.Next(600));
                Canvas.SetTop(ellipse, random.Next(600));

                grad.StartPoint = new Point(0, 0);
                grad.EndPoint = new Point(1, 1);

                var fColor = Color.FromRgb((byte)random.Next(byte.MaxValue), (byte)random.Next(byte.MaxValue), (byte)random.Next(byte.MaxValue));
                var sColor = Color.FromRgb((byte)random.Next(byte.MaxValue), (byte)random.Next(byte.MaxValue), (byte)random.Next(byte.MaxValue));
                var tColor = Color.FromRgb((byte)random.Next(byte.MaxValue), (byte)random.Next(byte.MaxValue), (byte)random.Next(byte.MaxValue));

                grad.GradientStops.Add(new GradientStop(fColor, 0.0));
                grad.GradientStops.Add(new GradientStop(sColor, 0.5));
                grad.GradientStops.Add(new GradientStop(tColor, 1.0));
                SibacaButton.Fill = grad;
            }
        }
    }
}