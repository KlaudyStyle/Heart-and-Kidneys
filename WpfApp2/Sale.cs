// Models/Sale.cs
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp2.Models
{
    public class Sale : INotifyPropertyChanged
    {
        private Client _client;
        public Client Client
        {
            get => _client;
            set { _client = value; OnPropertyChanged(); }
        }

        private Product _product;
        public Product Product
        {
            get => _product;
            set { _product = value; OnPropertyChanged(); }
        }

        private int _quantity;
        public int Quantity
        {
            get => _quantity;
            set { _quantity = value; OnPropertyChanged(); }
        }

        private DateTime _date = DateTime.Now;
        public DateTime Date
        {
            get => _date;
            set { _date = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}