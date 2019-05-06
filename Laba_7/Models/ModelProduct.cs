using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Laba_7.Models
{
    public class ModelProduct : INotifyPropertyChanged
    {
        private string _name;
        private string _measureUnit;
        private int _count;
        private double _price;
        private double _sum;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public string MeasureUnit
        {
            get => _measureUnit;
            set
            {
                _measureUnit = value;
                OnPropertyChanged("MeasureUnit");
            }
        }
        public int Count
        {
            get => _count;
            set
            {
                _count = value > 0 ? value : 1;
                OnPropertyChanged("Count");
                CalculationSum();
            }
        }
        public double Price
        {
            get => _price;
            set
            {
                _price = value > 0 ? value : 1;
                OnPropertyChanged("Price");
                CalculationSum();
            }
        }
        public double Sum
        {
            get => _sum;
            set
            {
                _sum = value > 0 ? value : 1;
                OnPropertyChanged("Sum");
            }
        }
        private void CalculationSum()
        {
            _sum = _price * _count;
        }

        public ModelProduct(string name, string measureUnit, int count, double price)
        {
            Name = name;
            MeasureUnit = measureUnit;
            Count = count;
            Price = price;
        }
        public ModelProduct() { }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
