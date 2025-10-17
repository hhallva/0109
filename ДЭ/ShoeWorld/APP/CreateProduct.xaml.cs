using DataLayer.Contexts;
using DataLayer.Models;
using System.Windows;

namespace APP
{
    /// <summary>
    /// Логика взаимодействия для CreateProduct.xaml
    /// </summary>
    public partial class CreateProduct : Window
    {
        public DeProduct product = new();
        public List<DeSupplier> supplier = [];
        public List<DeManufacturer> manufacturers = [];
        public static AppDbContext context = new AppDbContext();

        public CreateProduct()
        {
            InitializeComponent();

            supplier = context.DeSuppliers.ToList();
            manufacturers = context.DeManufacturers.ToList();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            NavifgateToShop();
        }

        private void NavifgateToShop()
        {
            var window = new ShopWindow();
            window.Show();
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
