using System;
using System.IO;
using System.Linq;
using System.Windows;
using Newtonsoft.Json;
using WpfApp2.Models;

namespace WpfApp2
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var users = JsonConvert.DeserializeObject<User[]>(File.ReadAllText("users.json"));
                var user = users.FirstOrDefault(u => u.Username == txtLogin.Text && u.Password == txtPassword.Password);
                
                if (user == null) throw new Exception("Неверные учетные данные");
                
                new MainWindow(user.Role).Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e) => Close();
    }
}