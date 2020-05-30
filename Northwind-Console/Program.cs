using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using NLog;
using NorthwindConsole.Models;
using System.Drawing;
using Console = Colorful.Console;

namespace NorthwindConsole
{
    class MainClass
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public static void Main(string[] args)
        {
            logger.Info("Program started");
            try
            {
                string choice;
                do
                {
                    //Sorry Mark, I prefer the switch over an if/else statement, hope you don't mind I changed it up.
                    Console.Clear();
                    //For a "C" Grade
                    Console.WriteLine("1) Add a Product");
                    Console.WriteLine("2) Display all Products");
                    Console.WriteLine("3) Display Active Products");
                    Console.WriteLine("4) Display Discontinued Products");
                    Console.WriteLine("5) Search Products");
                    //For a "B" Grade
                    Console.WriteLine("6) Add a Category");
                    Console.WriteLine("7) Edit a Category");
                    Console.WriteLine("8) Display all Categories");
                    Console.WriteLine("9) Display all non-discontinued items by a Category");
                    Console.WriteLine("10) Display all non-discontinued items by a specific Category");
                    //For an "A" Grade
                    Console.WriteLine("11) Delete a Category");
                    Console.WriteLine("12) Delete a Product");
                    Console.WriteLine("\"q\" to quit");
                    choice = Console.ReadLine();

                    switch(choice)
                    {
                        //add product
                        case "1":
                            {
                                Product.addProducts(logger);
                                break;
                            }
                        //display products
                        case "2":
                            {
                                Product.displayAllProducts(logger);
                                break;
                            }
                        //display active products
                        case "3":
                            {
                                Product.displayActiveProducts(logger);
                                break;
                            }
                        //display discountinued products
                        case "4":
                            {
                                Product.displayDiscontinuedProducts(logger);
                                break;
                            }
                        //search products
                        case "5":
                            {
                                Product.searchProducts(logger);
                                break;
                            }
                        //add category
                        case "6":
                            {
                                Category.addCategories(logger);
                                break;
                            }
                        //edit category
                        case "7":
                            {
                                var db = new NorthwindContext();
                                Console.WriteLine("Choose category ID to edit: ");
                                var category = Category.GetCategory(db, logger);

                                if (category != null)
                                {
                                    Category UpdatedCategory = Category.InputCategory(db, logger);

                                    if (UpdatedCategory != null)
                                    {
                                        UpdatedCategory.CategoryId = category.CategoryId;
                                        db.EditCategory(UpdatedCategory);
                                        logger.Info($"Category Id: {UpdatedCategory.CategoryId} updated");
                                    }
                                }
                                Console.WriteLine();
                                Console.WriteLine("Press any key to return to the Menu", Color.Red);
                                Console.ReadLine();
                                break;
                            }
                        //display all categories
                        case "8":
                            {
                                Category.displayAllCategories(logger);
                                break;
                            }
                        //display all non-discontinued items by Category
                        case "9":
                            {
                                Category.displayAllCategoriesProductsNotDiscontinued(logger);
                                break;
                            }
                        //display all non-discontinued items by specific Category
                        case "10":
                            {
                                Category.displaySpecificCategoryProducts(logger);
                                break;
                            }
                        //delete a category
                        case "11":
                            {
                                var db = new NorthwindContext();
                                Console.WriteLine("Select category ID to delete:");
                                var categoryToDelete = Category.GetCategory(db, logger);
                                try
                                {
                                    db.deleteCategory(categoryToDelete);
                                    logger.Info($"{categoryToDelete.CategoryName} deleted");
                                }
                                catch (Exception)
                                {
                                    logger.Error("Cannot Delete a record that affects other tables");
                                }
                                Console.WriteLine();
                                Console.WriteLine("Press any key to return to the Menu", Color.Red);
                                Console.ReadLine();
                                break;
                            }
                        //delete a product
                        case "12":
                            {
                                var db = new NorthwindContext();
                                Console.WriteLine("Select product ID to delete:");
                                var productToDelete = Product.getProduct(db, logger);
                                try
                                {
                                    db.deleteProduct(productToDelete);
                                    logger.Info($"{productToDelete.ProductName} deleted");
                                }
                                catch (Exception)
                                {
                                    logger.Error("Cannot Delete a record that will affect other tables");
                                }
                                Console.WriteLine();
                                Console.WriteLine("Press any key to return to the Menu", Color.Red);
                                Console.ReadLine();
                                break;
                            }
                    }

                } while (choice.ToLower() != "q");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
            logger.Info("Program ended");
        }
    }
}

//How to add color to the Console
//Must install the extension Colorful Consoles for it to work
//Must have: using System.Drawing; and using Console = Colorful.Console; at the top
//http://colorfulconsole.com/
