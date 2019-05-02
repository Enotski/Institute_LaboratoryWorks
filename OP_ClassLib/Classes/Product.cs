using System;
using System.Runtime.Serialization;

namespace OP_ClassLib
{
    [DataContract]
    [Serializable]
    public class Product
    {
        [DataMember]
        private int _count;
        [DataMember]
        private double _price;
        [DataMember]
        private double _sum;

        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string MeasureUnit { get; set; }
        [DataMember]
        public int Count
        {
            get => _count;
            set
            {
                _count = value > 0 ? value : 1;
            }
        }
        [DataMember]
        public double Price
        {
            get => _price;
            set
            {
                _price = value > 0 ? value : 1;
            }
        }
        [DataMember]
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
