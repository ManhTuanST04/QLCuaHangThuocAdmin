using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientWebAPI.Models
{
    public class ProductModel2
    {
        public ProductModel2()
        {

        }

        public ProductModel2(int id, String name, int price, int weight, String color, String image)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.weight = weight;
            this.color = color;
            this.image = image;
        }

        public int id { set; get; }

        public string name { set; get; }

        public int price { set; get; }

        public int weight { set; get; }

        public string color { set; get; }

        public string image { set; get; }
    }
}