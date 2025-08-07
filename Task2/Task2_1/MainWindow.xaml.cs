using Microsoft.Win32;
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
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Task2_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
        {

        private string? _status;
        public string? Status
        {
            get => _status; 
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged();
                }
            }
        }

        private string? _textBlockContent;
        public string? TextBlockContent
        {
            get => _textBlockContent; 
            set 
            {
                if (_textBlockContent != value)
                {
                    _textBlockContent = value;
                    OnPropertyChanged();
                }
            }
        }

        //private string _textBlockContent;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Status = "Готово";
        }
        

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Text|*.txt|All|*.*";
            if (fileDialog.ShowDialog() == false)
            {
                return;
            }

            try
            {
               TextBlockContent = File.ReadAllText(fileDialog.FileName);
                Status = $"Путь к открытому файлу: {fileDialog.FileName}";
                //TextReader.Text = TextBlockContent;
            }
            catch (Exception)
            {

                throw new Exception("Ошибка загрузки файла");
            }
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new SaveFileDialog();
            fileDialog.Filter = "Text|*.txt|All|*.*";
            if (fileDialog.ShowDialog() == false)
            {
                return;
            }

            try
            {
                File.WriteAllText(fileDialog.FileName, TextBlockContent);
                Status = "Файл сохранён";
            }
            catch (Exception)
            {

                throw new Exception("Ошибка сохранения файла");
            }
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            var projectInfo = new ProjectInfo();
            projectInfo.ShowDialog();

        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите выйти?", "Подтверждение",
                                   MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }


        //private void TextReader_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    TextBlockContent = TextReader.Text;
        //}
    }
}