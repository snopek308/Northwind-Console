using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using NLog;
using NorthwindConsole.Models;

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
                    Console.Clear();
                    Console.WriteLine("1) Add Product");
                    Console.WriteLine("2) Display all Products");
                    Console.WriteLine("3) Display Active Products");
                    Console.WriteLine("4) Display Discontinued Products");
                    Console.WriteLine("5) Search Products");
                    Console.WriteLine("6) Add Category");
                    Console.WriteLine("7) Edit Category");
                    Console.WriteLine("8) Display all Categories");
                    Console.WriteLine("9) Display all non-discontinued items by Category");
                    Console.WriteLine("10) Display all non-discontinued items by speciic Category");
                    Console.WriteLine("11) Delete Category");
                    Console.WriteLine("12) Delete Product");
                    Console.WriteLine("\"q\" to quit");
                    choice = Console.ReadLine();

                    switch(choice)
                    {
                        //add product
                        case "1":
                            {
                                break;
                            }
                        //display products
                        case "2":
                            {
                                break;
                            }
                        //display active products
                        case "3":
                            {
                                break;
                            }
                        //display discountinued products
                        case "4":
                            {
                                break;
                            }
                        //search products
                        case "5":
                            {
                                break;
                            }
                        //add category
                        case "6":
                            {
                                break;
                            }
                        //edit category
                        case "7":
                            {
                                break;
                            }
                        //display all categories
                        case "8":
                            {
                                break;
                            }
                        //display all non-discontinued items by Category
                        case "9":
                            {
                                break;
                            }
                        //display all non-discontinued items by speciic Category
                        case "10":
                            {
                                break;
                            }
                        //delete a category
                        case "11":
                            {
                                break;
                            }
                        //delete a product
                        case "12":
                            {
                                break;
                            }

                    }

                    //logger.Info($"Option {choice} selected");
                    //if (choice == "1")
                    //{
                    //    var db = new NorthwindContext();
                    //    var query = db.Categories.OrderBy(p => p.CategoryName);

                    //    Console.WriteLine($"{query.Count()} records returned");
                    //    foreach (var item in query)
                    //    {
                    //        Console.WriteLine($"{item.CategoryName} - {item.Description}");
                    //    }
                    //} 
                    //else if (choice == "2")
                    //{
                    //    Category category = new Category();
                    //    Console.WriteLine("Enter Category Name:");
                    //    category.CategoryName = Console.ReadLine();
                    //    Console.WriteLine("Enter the Category Description:");
                    //    category.Description = Console.ReadLine();

                    //    ValidationContext context = new ValidationContext(category, null, null);
                    //    List<ValidationResult> results = new List<ValidationResult>();

                    //    var isValid = Validator.TryValidateObject(category, context, results, true);
                    //    if (isValid)
                    //    {
                    //        var db = new NorthwindContext();
                    //        // check for unique name
                    //        if (db.Categories.Any(c => c.CategoryName == category.CategoryName))
                    //        {
                    //            // generate validation error
                    //            isValid = false;
                    //            results.Add(new ValidationResult("Name exists", new string[] { "CategoryName" }));
                    //        }
                    //        else
                    //        {
                    //            logger.Info("Validation passed");
                    //            // TODO: save category to db
                    //        }
                    //    }
                    //    if (!isValid)
                    //    {
                    //        foreach (var result in results)
                    //        {
                    //            logger.Error($"{result.MemberNames.First()} : {result.ErrorMessage}");
                    //        }
                    //    }
                    //} else if (choice == "3")
                    //{
                    //    var db = new NorthwindContext();
                    //    var query = db.Categories.OrderBy(p => p.CategoryId);

                    //    Console.WriteLine("Select the category whose products you want to display:");
                    //    foreach (var item in query)
                    //    {
                    //        Console.WriteLine($"{item.CategoryId}) {item.CategoryName}");
                    //    }
                    //    int id = int.Parse(Console.ReadLine());
                    //    Console.Clear();
                    //    logger.Info($"CategoryId {id} selected");
                    //    Category category = db.Categories.FirstOrDefault(c => c.CategoryId == id);
                    //    Console.WriteLine($"{category.CategoryName} - {category.Description}");
                    //    foreach(Product p in category.Products)
                    //    {
                    //        Console.WriteLine(p.ProductName);
                    //    }
                    //}
                    //else if (choice == "4")
                    //{
                    //    var db = new NorthwindContext();
                    //    var query = db.Categories.Include("Products").OrderBy(p => p.CategoryId);
                    //    foreach(var item in query)
                    //    {
                    //        Console.WriteLine($"{item.CategoryName}");
                    //        foreach(Product p in item.Products)
                    //        {
                    //            Console.WriteLine($"\t{p.ProductName}");
                    //        }
                    //    }
                    //}
                    //Console.WriteLine();

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
