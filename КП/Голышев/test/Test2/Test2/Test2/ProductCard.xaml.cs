using System.Windows;

namespace Test2
{
    public partial class MainWindow : Window
    {
        public MainWindow(string title, string price, string description)
        {

        }
        private void GoHomeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}