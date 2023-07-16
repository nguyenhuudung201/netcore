using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netcore
{
    internal class ProductController
    {
        ProductDBContext dbContext;
        public ProductController()
        {
            var productDbOptions = new DbContextOptionsBuilder<ProductDBContext>()
                .UseSqlServer("Data Source=DESKTOP-71IL0V1\\SEVERDUNG;Initial Catalog=product;User ID=sa;Password=040620;Encrypt=False")
                .Options;
            this.dbContext = new ProductDBContext(productDbOptions);
        }
        public void GetAllProducts()
        {
            var products = dbContext.Products.ToList();
            foreach (var item in products)
            {
                Console.WriteLine($"Hello {item.Name} {item.Desccribe} {item.Unit} {item.Price}");
            }
        }

        public void UpdateProducts()
        {
            Console.Write("Enter id to find Products : ");
            int id = Convert.ToInt32(Console.ReadLine());

            //Get Student By ID by LINQ
            Product updateProducts = (Product) dbContext.Products.Where(p => p.Id == id)
                                         .Single();


            if (updateProducts != null)
            {
                Console.WriteLine($"Hello {updateProducts.Name} {updateProducts.Desccribe}" +
                    $" {updateProducts.Unit} {updateProducts.Price}");
                Console.Write("Name : ");
                string? name = Console.ReadLine();
                Console.Write("Desccribe : ");
                string? desccribe = Console.ReadLine();
                Console.Write("Unit : ");
                string? unit = Console.ReadLine();
                Console.Write("Price : ");
                decimal price  = Convert.ToDecimal(Console.ReadLine());


                updateProducts.Name = name;
                updateProducts.Desccribe = desccribe;
                updateProducts.Unit = unit;
                updateProducts.Price = price;

                try
                {
                    dbContext.Products.Update(updateProducts);
                    dbContext.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }


        }
        public void DeleteProduct()
        {
            Console.Write("Enter id to find Products : ");
            int id = Convert.ToInt32(Console.ReadLine());


            Product deleteProduct = (Product)dbContext.Products.Where(p => p.Id== id)
                                         .Single();



            if ( !object.Equals(deleteProduct, null))
            {
                try
                {
                    dbContext.Products.Remove(deleteProduct);
                    dbContext.SaveChanges();
                    Console.WriteLine("Delete success");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else { Console.WriteLine("Not exsit"); }



        }
        public void SearchProduct()
        {
            Console.Write("Enter id to find Products : ");
            int id = Convert.ToInt32(Console.ReadLine());


            Product SearchProduct = (Product)dbContext.Products.Where(p => p.Id == id)
                                         .Single();



            if (SearchProduct != null)
            {
                try
                {
                    Console.WriteLine($" {SearchProduct.Name} {SearchProduct.Desccribe} {SearchProduct.Unit} {SearchProduct.Price}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }

        public void CreateNewProduct()
        {
            Console.Write("Name : ");
            string? name = Console.ReadLine();
            Console.Write("Desccribe : ");
            string? desccribe = Console.ReadLine();
            Console.Write("Unit : ");
            string? unit = Console.ReadLine();
            Console.Write("Price : ");
            decimal price = Convert.ToDecimal(Console.ReadLine());


            var product = new Product
            {
                Name = name,
                Desccribe = desccribe,
                Unit = unit,
                Price = price
           
            };

            try
            {
                dbContext.Products.Add(product);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
