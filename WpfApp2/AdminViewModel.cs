using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using Newtonsoft.Json;
using WpfApp2.Models;

namespace WpfApp2.ViewModels
{
    public class AdminViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users
        {
            get => _users;
            set { _users = value; OnPropertyChanged(); }
        }

        public ObservableCollection<string> Roles { get; } = new ObservableCollection<string>
{
    "Admin",
    "WarehouseManager",
    "User",
    "Seller"
};

        private string _selectedRole;
        public string SelectedRole
        {
            get => _selectedRole;
            set { _selectedRole = value; OnPropertyChanged(); }
        }

        private bool _isDirty;
        public bool IsDirty
        {
            get => _isDirty;
            set { _isDirty = value; OnPropertyChanged(); }
        }

        public RelayCommand AddUserCommand { get; }
        public RelayCommand DeleteUserCommand { get; }
        public RelayCommand SaveCommand { get; }

        public AdminViewModel()
        {
            Users = new ObservableCollection<User>(LoadUsers());
            AddUserCommand = new RelayCommand(_ => AddUser());
            DeleteUserCommand = new RelayCommand(DeleteUser);
            SaveCommand = new RelayCommand(_ => SaveUsers());
        }

        private void AddUser()
        {
            Users.Add(new User
            {
                Username = "Новый пользователь",
                Password = "12345",
                Role = "User",
                IsActive = true
            });
            IsDirty = true;
        }

        private void DeleteUser(object parameter)
        {
            if (parameter is User user)
            {
                Users.Remove(user);
                IsDirty = true;
            }
        }

        private List<User> LoadUsers()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "users.json");
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                var users = JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();
                return users;
            }
            return new List<User>();
        }

        public void SaveUsers()
        {
            try
            {
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "users.json");
                var json = JsonConvert.SerializeObject(Users, Formatting.Indented);
                File.WriteAllText(path, json);
                IsDirty = false;
                MessageBox.Show("Данные сохранены успешно!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}