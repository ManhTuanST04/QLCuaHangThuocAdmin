using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientWebAPI.Models
{
    public class ProductModel
    {
        public ProductModel()
        {

        }

        public ProductModel(int id, String name, int price, int weight, String color)
        {
            this.id = id;
            this.Name = name;
            this.Price = price;
            this.Weight = weight;
            this.Color = color;
        }

        public int id { set; get; }

        public string Name { set; get; }

        public int Price { set; get; }

        public int Weight { set; get; }

        public string Color { set; get; }

    }
}