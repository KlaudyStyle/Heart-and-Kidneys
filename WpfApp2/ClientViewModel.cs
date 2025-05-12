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
    public class ClientViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Client> _clients;
        public ObservableCollection<Client> Clients
        {
            get => _clients;
            set { _clients = value; OnPropertyChanged(); }
        }

        private string _searchQuery;
        public string SearchQuery
        {
            get => _searchQuery;
            set { _searchQuery = value; OnPropertyChanged(); }
        }

        private bool _isDirty;
        public bool IsDirty
        {
            get => _isDirty;
            set { _isDirty = value; OnPropertyChanged(); }
        }

        public RelayCommand AddClientCommand { get; }
        public RelayCommand DeleteClientCommand { get; }
        public RelayCommand SearchCommand { get; }
        public RelayCommand SaveCommand { get; }

        public ClientViewModel()
        {
            Clients = new ObservableCollection<Client>(LoadClients());
            AddClientCommand = new RelayCommand(_ => AddClient());
            DeleteClientCommand = new RelayCommand(DeleteClient);
            SearchCommand = new RelayCommand(_ => SearchClients());
            SaveCommand = new RelayCommand(_ => SaveClients());
        }

        private void AddClient()
        {
            Clients.Add(new Client
            {
                FirstName = "Новый",
                LastName = "Клиент",
                Phone = "",
                Email = ""
            });
            IsDirty = true;
        }

        private void DeleteClient(object parameter)
        {
            if (parameter is Client client)
            {
                Clients.Remove(client);
                IsDirty = true;
            }
        }

        private void SearchClients()
        {
            if (string.IsNullOrEmpty(SearchQuery))
            {
                Clients = new ObservableCollection<Client>(LoadClients());
                return;
            }

            var filtered = Clients.Where(c =>
                c.LastName.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase) ||
                c.FirstName.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase) ||
                c.Phone.Contains(SearchQuery) ||
                c.Email.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase)
            ).ToList();

            Clients = new ObservableCollection<Client>(filtered);
        }

        private List<Client> LoadClients()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "clients.json");
            return File.Exists(path)
                ? JsonConvert.DeserializeObject<List<Client>>(File.ReadAllText(path))
                : new List<Client>();
        }

        public void SaveClients()
        {
            try
            {
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "clients.json");
                File.WriteAllText(path, JsonConvert.SerializeObject(Clients, Formatting.Indented));
                IsDirty = false;
                MessageBox.Show("Данные клиентов сохранены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
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