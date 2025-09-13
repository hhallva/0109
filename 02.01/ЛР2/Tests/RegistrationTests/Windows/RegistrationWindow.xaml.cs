using System.Windows;
using static MyLibrary.MyMethods;

namespace RegistrationTests.Windows
{
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsValidFields())
                return;

            MessageBox.Show("Вы успешно зарегистрированы!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private bool IsValidFields()
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(LoginTextBox.Text))
                errors.Add("Введите логин");

            if (string.IsNullOrWhiteSpace(PasswordBox.Password))
                errors.Add("Введите пароль");
            else if (!IsValidPassword(PasswordBox.Password))
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
                MessageBox.Show(string.Join(Environment.NewLine, errors), "Ошибки регистрации", MessageBoxButton.OK, MessageBoxImage.Warning);
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
