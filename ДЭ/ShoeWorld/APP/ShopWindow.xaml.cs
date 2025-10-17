using DataLayer.Contexts;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace APP
{
    /// <summary>
    /// Логика взаимодействия для ShopWindow.xaml
    /// </summary>
    public partial class ShopWindow : Window
    {
        public List<DeProduct> products = [];
        public List<DeSupplier> supplier = [];
        public static AppDbContext context = new AppDbContext();

        public ShopWindow(DeUser? user = null)
        {
            InitializeComponent();

            if (user != null)
            {
                RoleLabel.Content = user.RoleId switch
                {
                    1 => "Администратор",
                    2 => "Менеджер",
                    3 => "Клиент",
                };

                FullNameText.Text = $"{user.Surname} {user.Name} {user.Patronymic}";

                if (user.RoleId != 3)
                {
                    FilterStackPanel.IsEnabled = false;
                }
            }

            if (user == null)
            {
                RoleLabel.Content = "Неавторизованный пользвователь";
                FilterStackPanel.IsEnabled = false;
            }

            products = context.DeProducts
                .Include(p => p.Manufacturer)
                .Include(p => p.Supplier)
                .ToList();

            supplier = context.DeSuppliers.ToList();

            ProductsListView.ItemsSource = products;
            FilterManufacturerButton.ItemsSource = supplier;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateToLoging();
        }

        private void NavigateToLoging()
        {
            var window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void FilterProducts()
        {
            var filteredProducts = products
                .Where(p => p.Name.ToLower().Contains(SearchTextBox.Text.ToLower()) ||
                       p.Description.ToLower().Contains(SearchTextBox.Text.ToLower()) ||
                       p.Price.ToString().Contains(SearchTextBox.Text) ||
                       p.Supplier.Name.ToLower().Contains(SearchTextBox.Text.ToLower()) ||
                       p.Manufacturer.Name.ToLower().Contains(SearchTextBox.Text.ToLower()) ||
                       p.GenderDisplay.ToLower().Contains(SearchTextBox.Text.ToLower()))
                .ToList();

            if (FilterButton.SelectedIndex == 0)
            {

                filteredProducts = filteredProducts.OrderByDescending(p => p.Amount).ToList();
            }
            if (FilterButton.SelectedIndex == 1)
            {

                filteredProducts = filteredProducts.OrderBy(p => p.Amount).ToList();
            }
            if (FilterManufacturerButton.SelectedIndex > -1)
            {
                if (FilterManufacturerButton.SelectedItem is DeSupplier supplier)
                    filteredProducts = filteredProducts.Where(p => p.Supplier.Name == supplier.Name).ToList();
            }


            ProductsListView.ItemsSource = filteredProducts;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            SearchTextBox.Text = string.Empty;
            FilterButton.SelectedIndex = -1;
            FilterManufacturerButton.SelectedIndex = -1;
            ProductsListView.ItemsSource = products;
        }

        private void SearchTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            FilterProducts();

        }

        private void FilterButton_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            FilterProducts();

        }

        private void FilterManufacturerButton_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            FilterProducts();

        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            NavifgateToCreate();
        }

        private void NavifgateToCreate()
        {
            var window = new CreateProduct();
            window.Show();
            this.Close();
        }
    }
}
