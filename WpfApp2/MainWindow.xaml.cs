using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using WpfApp2.ViewModels;
using WpfApp2.Views;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        public MainWindow(string role)
        {
            InitializeComponent();
            DataContext = new MainViewModel(role);
            Closing += (s, e) =>
            {
                if (DataContext is MainViewModel vm)
                {
                    foreach (var item in vm.MenuItems)
                    {
                        if (item.View is WarehouseView wv && wv.DataContext is WarehouseViewModel wvm)
                            wvm.SaveProducts();
                    }
                }
            };
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (DataContext is MainViewModel mainVM)
            {
                bool hasUnsaved = false;

                foreach (var item in mainVM.MenuItems)
                {
                    if (item.View is WarehouseView wv && wv.DataContext is WarehouseViewModel wvm && wvm.IsDirty)
                        hasUnsaved = true;

                    if (item.View is ClientView cv && cv.DataContext is ClientViewModel cvm && cvm.IsDirty)
                        hasUnsaved = true;
                }

                if (hasUnsaved)
                {
                    var result = MessageBox.Show("Сохранить изменения перед выходом?", "Внимание",
                        MessageBoxButton.YesNoCancel);

                    if (result == MessageBoxResult.Yes)
                    {
                        foreach (var item in mainVM.MenuItems)
                        {
                            if (item.View is WarehouseView wv && wv.DataContext is WarehouseViewModel wvm)
                                wvm.SaveProducts();

                            if (item.View is ClientView cv && cv.DataContext is ClientViewModel cvm)
                                cvm.SaveClients();
                        }
                    }
                    else if (result == MessageBoxResult.Cancel)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }
    }

    public class MainViewModel : INotifyPropertyChanged
    {
        private MenuItem _selectedItem;
        public MenuItem SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                CurrentView = _selectedItem?.View;
                OnPropertyChanged();
            }
        }
        public class MenuItem
        {
            public string Title { get; set; }
            public object View { get; set; }
        }

        private object _currentView;
        public object CurrentView
        {
            get => _currentView;
            set { _currentView = value; OnPropertyChanged(); }
        }

        public List<MenuItem> MenuItems { get; set; }

        public MainViewModel(string role)
        {
            MenuItems = new List<MenuItem>();

            switch (role)
            {
                case "Admin":
                    MenuItems.Add(new MenuItem { Title = "Админ", View = new AdminView() });
                    MenuItems.Add(new MenuItem { Title = "Склад", View = new WarehouseView() });
                    MenuItems.Add(new MenuItem { Title = "Клиенты", View = new ClientView() });
                    break;
                case "WarehouseManager":
                    MenuItems.Add(new MenuItem { Title = "Склад", View = new WarehouseView() });
                    break;
                case "Seller":
                    MenuItems.Add(new MenuItem { Title = "Клиенты", View = new ClientView() });
                    break;
            }

            CurrentView = MenuItems.FirstOrDefault()?.View;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}