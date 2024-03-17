using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPLab9
{
    public class ToyModel
    {
        public string Name { get; set; }
        public string ManufacturerCountry { get; set; }
        public double Price { get; set; }
        public string TypeOfToy { get; set; }
        public string ImagePath { get; set; }

        public ToyModel() { }

        public ToyModel(string name, string manufacturerCountry, double price, string typeOfToy, string imagePath)
        {
            Name = name;
            ManufacturerCountry = manufacturerCountry;
            Price = price;
            TypeOfToy = typeOfToy;
            ImagePath = imagePath;
        }
    }
}
