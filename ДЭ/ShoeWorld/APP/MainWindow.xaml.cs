using API.Controllers;
using DataLayer.Contexts;
using DataLayer.DTOs;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Windows;

namespace APP
{
    public partial class MainWindow : Window
    {
        public static AppDbContext context = new AppDbContext();
        public AccountController AccountController = new AccountController(context);


        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (LoginText.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Введите логин","Ошибка",MessageBoxButton.OK,MessageBoxImage.Warning);
                return;
            }
            if (PasswordText.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Введите пароль","Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var user = context.DeUsers.FirstOrDefault(u => u.Login == LoginText.Text.Trim());
            if (user == null)
            {
                MessageBox.Show("Пользователь не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (PasswordText.Text.Trim() != user.Password)
            {
                MessageBox.Show("Пароль не верный", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //MessageBox.Show("Авторизация успешна");
            NavigateToShop(user);
        }

        private void GuestButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateToShop();
        }
        private void NavigateToShop(DeUser? deUser = null)
        {
            var secondWindow = new ShopWindow(deUser);
            secondWindow.Show();
            this.Close();
        }
    }
}