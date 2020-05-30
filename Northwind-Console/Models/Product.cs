using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Drawing;
using Console = Colorful.Console;

namespace NorthwindConsole.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Enter name Please")]
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }

        [Required(ErrorMessage = "ENTER UNIT PRICE")]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(-9999999999999999.99, 9999999999999999.99)]
        public decimal? UnitPrice { get; set; }
        [Required(ErrorMessage = "Enter Units in Stock")]
        [Range(0, int.MaxValue, ErrorMessage = "Enter a Valid Number")]
        public Int16? UnitsInStock { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Enter a Valid Number")]
        public Int16? UnitsOnOrder { get; set; }
        [Required(ErrorMessage = "Enter reorder level")]
        [Range(0, int.MaxValue, ErrorMessage = "Enter a Valid Number")]
        public Int16? ReorderLevel { get; set; }
        [Required(ErrorMessage = "Enter Y/N for Discontinued")]
        public bool Discontinued { get; set; }

        public int? CategoryId { get; set; }
        public int? SupplierId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }


        //Methods for Switch Products

        //Case 1
        public static void addProducts(Logger logger)
        {
            logger.Info("Choice: Add new Product");
            var db = new NorthwindContext();
            Product product = new Product();

            Console.WriteLine("Enter the Product name: ");
            product.ProductName = Console.ReadLine();
            Console.WriteLine("Enter the Quantity per Unit: ");
            product.QuantityPerUnit = Console.ReadLine();
            Console.WriteLine("Enter the Unit Price: ");
            Decimal unitPrice = Decimal.Parse(Console.ReadLine());
            product.UnitPrice = unitPrice;
            Console.WriteLine("Enter the Units in Stock: ");
            Int16 unitsInStock = Int16.Parse(Console.ReadLine());
            product.UnitsInStock = unitsInStock;
            Console.WriteLine("Enter the Units on Order: ");
            Int16 unitsOnOrder = Int16.Parse(Console.ReadLine());
            product.UnitsOnOrder = unitsOnOrder;
            Console.WriteLine("Enter the reorder level: ");
            Int16 reorderLevel = Int16.Parse(Console.ReadLine());
            product.ReorderLevel = reorderLevel;
            Console.WriteLine("Enter if Discontinued Y/N");
            string discontinuedProduct = Console.ReadLine().ToLower();
            bool discontinued;

            //This is taking care of if the product is discountinued or not
            if (discontinuedProduct != null && discontinuedProduct.Equals("y") || discontinuedProduct.Equals("n"))
            {
                if (discontinuedProduct.Equals("y"))
                {
                    discontinued = true;
                    product.Discontinued = discontinued;
                }
                else if (discontinuedProduct.Equals("n"))
                {
                    discontinued = false;
                    product.Discontinued = discontinued;
                }

                //this is assigning the product to a category
                Console.WriteLine("Enter Category Name: ");
                var categoryName = Console.ReadLine().ToLower();
                var categoryQuery = db.Categories.Where(c => c.CategoryName.Equals(categoryName));
                var categoryID = 0;

                foreach (var ca in categoryQuery)
                {
                    categoryID = ca.CategoryId;
                }

                //this is assigning the product to a supplier
                product.CategoryId = categoryID;
                Console.WriteLine("Enter Supplier name: ");
                var supplierName = Console.ReadLine();
                var supplierQuery = db.Suppliers.Where(s => s.CompanyName.Equals(supplierName));
                var supplierID = 0;

                foreach (var s in supplierQuery)
                {
                    supplierID = s.SupplierId;
                }

                product.SupplierId = supplierID;

                ValidationContext context = new ValidationContext(product, null, null);
                List<ValidationResult> results = new List<ValidationResult>();
                var isValid = Validator.TryValidateObject(product, context, results, true);

                //This if/else is if the var isProductValid = true;
                if (db.Products.Any(p => p.ProductName.ToLower() == product.ProductName))
                {
                    //and if isProductValid = false;
                    isValid = false;
                    results.Add(new ValidationResult("Product already exists", new string[] { product.ProductName }));
                }

                if (isValid)
                {
                    logger.Info("Validation Passed");
                    db.addProduct(product);
                    logger.Info($"Product {product.ProductName} added");
                }
                else if (!isValid)
                {
                    foreach (var result in results)
                    {
                        logger.Error($"{result.MemberNames.First()} : {result.ErrorMessage}");
                    }

                }
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to return to the Menu", Color.Red);
            Console.ReadLine();
        }

        //Case 2
        public static void displayAllProducts(Logger logger)
        {
            //This is just querying through all the products and ordering them by their ProductID
            logger.Info("Choice: Display all Products");
            var db = new NorthwindContext();
            var queryProduct = db.Products.OrderBy(p => p.ProductID);
            logger.Info(queryProduct.Count());
            //I love foreach's now. this is going through the var queryProduct and writing out all the Product Name's in it
            foreach (var p in queryProduct)
            {
                Console.WriteLine($"{p.ProductName}");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to return to the Menu", Color.Red);
            Console.ReadLine();
        }

        //Case 3
        public static void displayActiveProducts(Logger logger)
        {
            logger.Info("Choice: Display Active Products");
            var db = new NorthwindContext();

            //This is looking through all the products and looking for when Discontinued is equal to false, and then displaying
            //those products bc they are active
            Console.WriteLine("All Active Products:");
            var ProductQuery = db.Products.Where(p => p.Discontinued == false);
            foreach (var p in ProductQuery)
            {
                Console.WriteLine($"{p.ProductName}");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to return to the Menu", Color.Red);
            Console.ReadLine();
        }

        //Case 4
        public static void displayDiscontinuedProducts(Logger logger)
        {
            logger.Info("Choice: Display Discontinued Products");
            var db = new NorthwindContext();

            Console.WriteLine("Discontinued Products:");
            //This is just the opposite search of above, where we are looking for where Discontinued is true, and 
            //displaying those products
            var ProductQuery = db.Products.Where(p => p.Discontinued == true);
            foreach (var p in ProductQuery)
            {
                Console.WriteLine($"{p.ProductName}");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to return to the Menu", Color.Red);
            Console.ReadLine();
        }

        //Case 5
        public static void searchProducts(Logger logger)
        {
            logger.Info("Choice: Search Products");
            var db = new NorthwindContext();
            Console.WriteLine("Enter a Product name: ");
            string name = Console.ReadLine().ToLower();
            logger.Info($"User search for {name.ToUpper()}");

            //When searching Products, this is looking for the matching name and if any match, the foreach
            //cycles through and displays all the information about the product
            var ProductSearch = db.Products.Where(p => p.ProductName.Equals(name));
            if (ProductSearch.Any())
            {
                Console.WriteLine($"Search Results for {name.ToUpper()}");
                foreach (var p in ProductSearch)
                {
                    Console.WriteLine($"Product ID: {p.ProductID}");
                    Console.WriteLine($"Supplier ID: {p.SupplierId}");
                    Console.WriteLine($"Category ID: {p.CategoryId}");
                    Console.WriteLine($"Quantity Per Unit: {p.QuantityPerUnit}");
                    Console.WriteLine($"Unit Price: {p.UnitPrice}");
                    Console.WriteLine($"Units In Stock: {p.UnitsInStock}");
                    Console.WriteLine($"Units On Order: {p.UnitsOnOrder}");
                    Console.WriteLine($"Reorder Level: {p.ReorderLevel}");

                    if (p.Discontinued == false)
                    {
                        Console.WriteLine("Discontinued: No");
                    }
                    else if (p.Discontinued == true)
                    {
                        Console.WriteLine("Discontinued: Yes");
                    }
                    Console.WriteLine();
                }
            }
            //if the entered product matches another, it will display the following Console.WriteLine
            else
            {
                Console.WriteLine($"There were {ProductSearch.Count()} products that matched \"{name.ToUpper()}\"");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to return to the Menu", Color.Red);
            Console.ReadLine();
        }

        //Case 12
        public static Product getProduct(NorthwindContext db, Logger logger)
        {
            //This is searching for the Product ID, and then using the foreach, displaying any Product/ProductID that mataches
            var products = db.Products.OrderBy(c => c.ProductName);
            foreach (Product p in products)
            {
                Console.WriteLine($"ID:{p.ProductID}) {p.ProductName}");
            }

            if (int.TryParse(Console.ReadLine(), out int ProductID))
            {
                Product product = db.Products.FirstOrDefault(p => p.ProductID == ProductID);
                if (product != null)
                {
                    return product;
                }
            }
            logger.Error("Invalid Product ID");
            return null;

        }
    }
}

