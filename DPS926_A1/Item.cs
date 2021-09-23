using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace DPS926_A1
{
    public class Item : INotifyPropertyChanged
    {
        private string _name;
        public string name 
        { 
            get { return _name; }
            set
            {
                if(_name != value)
                {
                    _name = value;
                    OnPropertyChanged("name");
                }
            }
        }

        private int _qty;
        public int qty
        {
            get { return _qty; }
            set
            {
                if (_qty != value)
                {
                    _qty = value;
                    OnPropertyChanged("qty");
                }
            }
        }

        private double _price;
        public double price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    OnPropertyChanged("price");
                }
            }
        }

        public Item() { }

        public Item(string name, int qty, double price)
        {
            this.name = name;
            this.qty = qty;
            this.price = price;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}