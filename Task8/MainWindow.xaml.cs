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

namespace Task8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void LoadProducts()
        {
            var products = new List<Product>
            {
                new Product
                {
                    Name = "Хлеб",
                    Price = 50,
                    ImagePath = "Images/icons8-хлеб-64.png",
                    Category = Category.Food
                },
                new Product
                {
                    Name = "Холодильник",
                    Price = 25000,
                    ImagePath = "Images/icons8-холодильник-64.png",
                    Category = Category.Appliances
                },
                new Product
                {
                    Name = "Молоко",
                    Price = 80,
                    ImagePath = "Images/icons8-молоко-64.png",
                    Category = Category.Food
                },
                 new Product
                {
                    Name = "Сыр",
                    Price = 220,
                    ImagePath = "Images/icons8-сыр-64.png",
                    Category = Category.Food
                },
                new Product
                {
                    Name = "Стиральная машина",
                    Price = 18000,
                    ImagePath = "Images/icons8-стиральная-машина-64.png",
                    Category = Category.Appliances
                }
            };

            ProductsListBox.ItemsSource = products;
        }
    }

}