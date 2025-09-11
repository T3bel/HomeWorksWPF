using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.Packaging;
using System.Runtime.CompilerServices;
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

namespace Task3_1
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        private ObservableCollection<string> _faculty;
        public ObservableCollection<string> Faculty
        {
            get => _faculty;
            set
            {
                if (_faculty != value)
                {
                    _faculty = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<string> _courses;
        public ObservableCollection<string> Courses
        {
            get => _courses;
            set
            {
                if (_courses != value)
                {
                    _courses = value;
                    OnPropertyChanged();
                }
            }
        }

        private Dictionary<string, ObservableCollection<string>> _sourceSelector = new Dictionary<string, ObservableCollection<string>>();


        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _sourceSelector.Add("Программирование", new ObservableCollection<string> { "Основы C#", "WPF", "Базы данных" });
            _sourceSelector.Add("Дизайн", new ObservableCollection<string> { "Графический дизайн", "UI/UX дизайн", "CSS" });
            _sourceSelector.Add("Менеджмент", new ObservableCollection<string> { "Основы менеджмента", "Управление проектами", "Управление цифровой информации бизнеса" });
            Faculty = new ObservableCollection<string>(_sourceSelector.Keys.ToList());
        }


        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(StudentNameTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите имя студента.", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!AgreementCheckBox.IsChecked ?? false)
            {
                MessageBox.Show("Необходимо согласие на обработку данных.", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string studentName = StudentNameTextBox.Text;
            string faculty = (FacultyComboBox.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "Не выбран";
            string studyForm = FullTimeRadio.IsChecked == true ? "Очно" : "Заочно";
            int hoursPerWeek = (int)HoursSlider.Value;

            var selectedCourses = CoursesListBox.SelectedItems.Cast<string>().ToList();


            if (selectedCourses.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите хотя бы один курс.", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string coursesList = string.Join("\n- ", selectedCourses);

            string message = $"Заявка на запись:\n\n" +
                            $"Студент: {studentName}\n" +
                            $"Факультет: {faculty}\n" +
                            $"Форма обучения: {studyForm}\n" +
                            $"Часов в неделю: {hoursPerWeek}\n\n" +
                            $"Выбранные курсы:\n- {coursesList}\n\n" +
                            $"Заявка успешно отправлена!";

            MessageBox.Show(message, "Успешная запись",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void FacultyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Courses = _sourceSelector[FacultyComboBox.SelectedItem.ToString()];
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
