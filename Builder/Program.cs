using System;
using System.Text;
using System.Collections.Generic;

namespace ConsoleApp15
{



    public interface IBuilder
    {

        void bread();

        void cutlet();

        void ketchup();

        void mustard();

        void mayonnaise();

        void chees();

        void cucumber();

        void tomato();

        void onion();

    }

    public class ConcreteBuilder : IBuilder
    {
        private Product _product = new Product();

        public ConcreteBuilder()
        {
            this.Reset();
        }
        public void Reset()
        {
            this._product = new Product();
        }
        public void cutlet()
        {
            this._product.Add("котлета");
        }
        public void ketchup()
        {
            this._product.Add("кетчуп");
        }

        public void mustard()
        {
            this._product.Add("горчица");
        }

        public void bread()
        {
            this._product.Add("булочка");
        }
        public void mayonnaise()
        {
            this._product.Add("майонез");
        }
        public void chees()
        {
            this._product.Add("сыр");
        }
        public void cucumber()
        {
            this._product.Add("огурчик");
        }
        public void tomato()
        {
            this._product.Add("томат");
        }
        public void onion()
        {
            this._product.Add("лучок");
        }

        public Product GetProduct()
        {
            Product result = this._product;

            this.Reset();

            return result;
        }
    }


    public class Product
    {
        private List<object> _parts = new List<object>();

        public void Add(string part)
        {
            this._parts.Add(part);
        }

        public string ListParts()
        {
            string str = string.Empty;

            for (int i = 0; i < this._parts.Count; i++)
            {
                str += this._parts[i] + ", ";
            }

            str = str.Remove(str.Length - 2); // removing last ",c"

            return "Рецепт гамбургера: " + str + "\n";
        }
    }

    public class Director
    {
        private IBuilder _builder;

        public IBuilder Builder
        {
            set { _builder = value; }
        }

        public void BuildMinimalViableProduct()
        {
            this._builder.cutlet();
            this._builder.bread();

            this._builder.ketchup();
            this._builder.mayonnaise();

        }

        public void BuildFullFeaturedProduct()
        {
            this._builder.cutlet();
            this._builder.bread();
            this._builder.chees();
            this._builder.ketchup();
            this._builder.cucumber();
            this._builder.mustard();
            this._builder.onion();
            this._builder.tomato();
            this._builder.mayonnaise();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var director = new Director();
            var builder = new ConcreteBuilder();
            director.Builder = builder;

            Console.WriteLine("Бургер:");
            director.BuildFullFeaturedProduct();
            Console.WriteLine(builder.GetProduct().ListParts());

            Console.WriteLine("Только котлета:");
            builder.cutlet();
            Console.WriteLine(builder.GetProduct().ListParts());

            Console.WriteLine("Простейший бургер:");
            director.BuildMinimalViableProduct();
            Console.WriteLine(builder.GetProduct().ListParts());


            Console.WriteLine("Без майонеза:");
            builder.cutlet();
            builder.bread();
            builder.chees();
            builder.cucumber();
            builder.mustard();
            builder.onion();
            builder.tomato();
            Console.Write(builder.GetProduct().ListParts());
        }
    }
}