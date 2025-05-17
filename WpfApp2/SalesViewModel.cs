// ViewModels/SalesViewModel.cs
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
    public class SalesViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Sale> _sales;
        public ObservableCollection<Sale> Sales
        {
            get => _sales;
            set { _sales = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Product> _availableProducts;
        public ObservableCollection<Product> AvailableProducts
        {
            get => _availableProducts;
            set { _availableProducts = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Client> _clients;
        public ObservableCollection<Client> Clients
        {
            get => _clients;
            set { _clients = value; OnPropertyChanged(); }
        }

        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get => _selectedProduct;
            set { _selectedProduct = value; OnPropertyChanged(); }
        }

        private Client _selectedClient;
        public Client SelectedClient
        {
            get => _selectedClient;
            set { _selectedClient = value; OnPropertyChanged(); }
        }

        private int _saleQuantity;
        public int SaleQuantity
        {
            get => _saleQuantity;
            set { _saleQuantity = value; OnPropertyChanged(); }
        }

        public RelayCommand SellCommand { get; }

        public SalesViewModel()
        {
            Sales = new ObservableCollection<Sale>(LoadSales());
            AvailableProducts = new ObservableCollection<Product>(LoadProducts());
            Clients = new ObservableCollection<Client>(LoadClients());
            SellCommand = new RelayCommand(_ => SellProduct());
        }

        private void SellProduct()
        {
            if (SelectedClient == null || SelectedProduct == null || SaleQuantity <= 0)
            {
                MessageBox.Show("Заполните все поля корректно");
                return;
            }

            if (SelectedProduct.Quantity < SaleQuantity)
            {
                MessageBox.Show("Недостаточно товара на складе");
                return;
            }

            // Обновляем количество товара
            SelectedProduct.Quantity -= SaleQuantity;

            // Добавляем продажу
            Sales.Add(new Sale
            {
                Client = SelectedClient,
                Product = SelectedProduct,
                Quantity = SaleQuantity,
                Date = DateTime.Now
            });

            SaveSales();
            SaveProducts();
            MessageBox.Show("Продажа оформлена!");
        }

        private List<Sale> LoadSales()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sales.json");
            return File.Exists(path)
                ? JsonConvert.DeserializeObject<List<Sale>>(File.ReadAllText(path))
                : new List<Sale>();
        }

        private List<Product> LoadProducts()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "products.json");
            return File.Exists(path)
                ? JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText(path))
                : new List<Product>();
        }

        private List<Client> LoadClients()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "clients.json");
            return File.Exists(path)
                ? JsonConvert.DeserializeObject<List<Client>>(File.ReadAllText(path))
                : new List<Client>();
        }

        private void SaveSales()
        {
            File.WriteAllText("sales.json", JsonConvert.SerializeObject(Sales));
        }

        private void SaveProducts()
        {
            File.WriteAllText("products.json", JsonConvert.SerializeObject(AvailableProducts));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}