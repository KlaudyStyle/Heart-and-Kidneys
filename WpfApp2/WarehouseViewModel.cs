using System;
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
    public class WarehouseViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }

        private string _searchQuery;
        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                _searchQuery = value;
                OnPropertyChanged();
            }
        }

        private bool _isDirty;
        public bool IsDirty
        {
            get => _isDirty;
            set
            {
                _isDirty = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand NewSupplyCommand { get; }
        public RelayCommand SearchCommand { get; }
        public RelayCommand SaveCommand { get; }

        public WarehouseViewModel()
        {
            Products = new ObservableCollection<Product>(LoadProducts());
            NewSupplyCommand = new RelayCommand(_ => AddNewSupply());
            SearchCommand = new RelayCommand(_ => SearchProducts());
            SaveCommand = new RelayCommand(_ => SaveProducts());
        }

        private void AddNewSupply()
        {
            Products.Add(new Product
            {
                Name = "Новая поставка",
                Quantity = 0,
                Supplier = "Не указан",
                Date = DateTime.Now
            });
            IsDirty = true;
            SaveProducts();
        }

        private void SearchProducts()
        {
            if (string.IsNullOrEmpty(SearchQuery))
            {
                Products = new ObservableCollection<Product>(LoadProducts());
                return;
            }

            var filtered = Products
                .Where(p => p.Name.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase))
                .ToList();

            Products = new ObservableCollection<Product>(filtered);
        }

        private List<Product> LoadProducts()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "products.json");
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<List<Product>>(json) ?? new List<Product>();
            }
            return new List<Product>();
        }

        public void SaveProducts()
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "products.json");
                string json = JsonConvert.SerializeObject(Products, Formatting.Indented);
                File.WriteAllText(path, json);
                IsDirty = false;
                MessageBox.Show("Данные успешно сохранены!", "Сохранение", MessageBoxButton.OK, MessageBoxImage.Information);
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