// See https://aka.ms/new-console-template for more information
using netcore;
using System;
using System.Numerics;
ProductController productController = new ProductController();

do
{
    Console.WriteLine("1. Add Product  ");
    Console.WriteLine("2. Update Product");
    Console.WriteLine("3. Delete Product");
    Console.WriteLine("4. Search Product");
    Console.WriteLine("5. Get All Product");
    Console.WriteLine("6. Exit");

    Console.WriteLine("Choose menu: ");


    int choose = Convert.ToInt32(Console.ReadLine());
    switch (choose)
    {
        case 1:
          productController.CreateNewProduct();
            break;
        case 2:
            productController.UpdateProducts();
            break;
        case 3:
            productController.DeleteProduct();
            break;
        case 4:
            productController.SearchProduct();
            break;
        case 5:
            productController.GetAllProducts();
            break;
        case 6:
            return;
    }
} while (true);
