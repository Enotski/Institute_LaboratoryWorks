using System;

namespace OP_ClassLib
{
    [Serializable]
    public class Product
    {
        private int _count;
        private double _price;
        private double _sum;

        public string Name { get; set; }
        public string MeasureUnit { get; set; }
        public int Count
        {
            get => _count;
            set
            {
                _count = value > 0 ? value : 1;
            }
        }
        public double Price
        {
            get => _price;
            set
            {
                _price = value > 0 ? value : 1;
            }
        }
        public double Sum
        {
            get => _sum;
            set
            {
                _sum = value > 0 ? value : 1;
            }
        }

        public Product(string name, string measureUnit, int count, double price)
        {
            Name = name;
            MeasureUnit = measureUnit;
            Count = count;
            Price = price;
        }
        public Product() { }
    }
}
