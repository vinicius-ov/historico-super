using System;
using System.Collections.Generic;
using System.ComponentModel;
using Todoer.Model;

namespace Todoer
{
    public class Product : INotifyPropertyChanged
    {
        string name = string.Empty;
        public String DisplayName
        {
            get => name;
            set
            {
                if (name == value)
                {
                    return;
                }
                name = value;
                OnPropertyChanged(nameof(DisplayName));
            }
        }

        //public List<DatedPrice> Prices { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        //public Product()
        //{
        //    Prices = new List<DatedPrice>();
        //}

    }

}
