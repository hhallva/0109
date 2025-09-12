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
using Tests;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AuthTest
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

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateFields())
                return;

            MessageBox.Show("Успешная регистрация");
        }

        private bool ValidateFields()
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(LoginTextBox.Text))
                errors.Add("Введите логин");

            if (string.IsNullOrWhiteSpace(PasswordBox.Password))
                errors.Add("Введите пароль");
            else if(!MyMethods.IsValidPassword(PasswordBox.Password))
                errors.Add("Введите корректный пароль");

            if (string.IsNullOrWhiteSpace(ConfirmPasswordBox.Password))
                errors.Add("Подтвердите пароль");

            if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
                errors.Add("Введите email");
            else if (!IsValidEmail(EmailTextBox.Text))
                errors.Add("Введите корректный email");

            if (!string.IsNullOrWhiteSpace(PasswordBox.Password) &&
                !string.IsNullOrWhiteSpace(ConfirmPasswordBox.Password) &&
                PasswordBox.Password != ConfirmPasswordBox.Password)
            {
                errors.Add("Пароли не совпадают");
            }

            if (errors.Count > 0)
            {
                MessageBox.Show(string.Join(Environment.NewLine, errors),
                               "Ошибки заполнения",
                               MessageBoxButton.OK,
                               MessageBoxImage.Warning);
                return false;
            }

            return true;
        }


        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}