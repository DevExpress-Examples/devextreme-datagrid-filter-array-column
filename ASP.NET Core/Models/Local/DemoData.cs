using System.Collections.Generic;
using System.Linq;

namespace ASP_NET_Core.Models.Local;

public static class DemoData {
    public static List<Category> Categories = [
        new Category {
            CategoryId = 1,
            CategoryName = "Beverages",
            Description = "Soft drinks, coffees, teas, beers, and ales",
            Products = [1, 2, 24, 34, 35, 38, 39, 43, 67, 70, 75, 76],
            SimpleProducts = [
                "Chai", "Chang", "Guaraná Fantástica", "Sasquatch Ale", "Steeleye Stout",
                "Côte de Blaye", "Chartreuse verte", "Ipoh Coffee", "Laughing Lumberjack Lager",
                "Outback Lager", "Rhönbräu Klosterbier", "Lakkalikööri"
            ]
        },
        new Category {
            CategoryId = 2,
            CategoryName = "Condiments",
            Description = "Sweet and savory sauces, relishes, spreads, and seasonings",
            Products = [3, 4, 5, 6, 8, 15, 44, 61, 63, 65, 66, 77],
            SimpleProducts = [
                "Aniseed Syrup", "Chef Anton's Cajun Seasoning", "Chef Anton's Gumbo Mix",
                "Grandma's Boysenberry Spread", "Northwoods Cranberry Sauce", "Genen Shouyu",
                "Gula Malacca", "Sirop d'érable", "Vegie-spread", "Louisiana Fiery Hot Pepper Sauce",
                "Louisiana Hot Spiced Okra", "Original Frankfurter grüne Soße"
            ]
        },
        new Category {
            CategoryId = 3,
            CategoryName = "Confections",
            Description = "Desserts, candies, and sweet breads",
            Products = [16, 19, 20, 21, 25, 26, 27, 47, 48, 49, 50, 62, 68],
            SimpleProducts = [
                "Pavlova", "Teatime Chocolate Biscuits", "Sir Rodney's Marmalade", "Sir Rodney's Scones",
                "NuNuCa Nuß-Nougat-Creme", "Gumbär Gummibärchen", "Schoggi Schokolade", "Zaanse koeken",
                "Chocolade", "Maxilaku", "Valkoinen suklaa", "Tarte au sucre", "Scottish Longbreads"
            ]
        },
        new Category {
            CategoryId = 4,
            CategoryName = "Dairy Products",
            Description = "Cheeses",
            Products = [11, 12, 31, 32, 33, 59, 60, 69, 71, 72],
            SimpleProducts = [
                "Queso Cabrales", "Queso Manchego La Pastora", "Gorgonzola Telino", "Mascarpone Fabioli",
                "Geitost", "Raclette Courdavault", "Camembert Pierrot", "Gudbrandsdalsost",
                "Flotemysost", "Mozzarella di Giovanni"
            ]
        },
        new Category {
            CategoryId = 5,
            CategoryName = "Grains/Cereals",
            Description = "Breads, crackers, pasta, and cereal",
            Products = [22, 23, 42, 52, 56, 57, 64],
            SimpleProducts = [
                "Gustaf's Knäckebröd", "Tunnbröd", "Singaporean Hokkien Fried Mee", "Filo Mix",
                "Gnocchi di nonna Alice", "Ravioli Angelo", "Wimmers gute Semmelknödel"
            ]
        },
        new Category {
            CategoryId = 6,
            CategoryName = "Meat/Poultry",
            Description = "Prepared meats",
            Products = [9, 17, 29, 53, 54, 55],
            SimpleProducts = [
                "Mishi Kobe Niku", "Alice Mutton", "Thüringer Rostbratwurst", "Perth Pasties",
                "Tourtière", "Pâté chinois"
            ]
        },
        new Category {
            CategoryId = 7,
            CategoryName = "Produce",
            Description = "Dried fruit and bean curd",
            Products = [7, 14, 28, 51, 74],
            SimpleProducts = [
                "Uncle Bob's Organic Dried Pears", "Tofu", "Rössle Sauerkraut", "Manjimup Dried Apples",
                "Longlife Tofu"
            ]
        },
        new Category {
            CategoryId = 8,
            CategoryName = "Seafood",
            Description = "Seaweed and fish",
            Products = [10, 13, 18, 30, 36, 37, 40, 41, 45, 46, 58, 73],
            SimpleProducts = [
                "Ikura", "Konbu", "Carnarvon Tigers", "Nord-Ost Matjeshering", "Inlagd Sill",
                "Gravad lax", "Boston Crab Meat", "Jack's New England Clam Chowder", "Rogede sild",
                "Spegesild", "Escargots de Bourgogne", "Röd Kaviar"
            ]
        }
    ];

    public static List<Product> Products = [
        new Product { Id = 1, Name = "Chai" },
        new Product { Id = 2, Name = "Chang" },
        new Product { Id = 3, Name = "Aniseed Syrup" },
        new Product { Id = 4, Name = "Chef Anton's Cajun Seasoning" },
        new Product { Id = 5, Name = "Chef Anton's Gumbo Mix" },
        new Product { Id = 6, Name = "Grandma's Boysenberry Spread" },
        new Product { Id = 7, Name = "Uncle Bob's Organic Dried Pears" },
        new Product { Id = 8, Name = "Northwoods Cranberry Sauce" },
        new Product { Id = 9, Name = "Mishi Kobe Niku" },
        new Product { Id = 10, Name = "Ikura" },
        new Product { Id = 11, Name = "Queso Cabrales" },
        new Product { Id = 12, Name = "Queso Manchego La Pastora" },
        new Product { Id = 13, Name = "Konbu" },
        new Product { Id = 14, Name = "Tofu" },
        new Product { Id = 15, Name = "Genen Shouyu" },
        new Product { Id = 16, Name = "Pavlova" },
        new Product { Id = 17, Name = "Alice Mutton" },
        new Product { Id = 18, Name = "Carnarvon Tigers" },
        new Product { Id = 19, Name = "Teatime Chocolate Biscuits" },
        new Product { Id = 20, Name = "Sir Rodney's Marmalade" },
        new Product { Id = 21, Name = "Sir Rodney's Scones" },
        new Product { Id = 22, Name = "Gustaf's Knäckebröd" },
        new Product { Id = 23, Name = "Tunnbröd" },
        new Product { Id = 24, Name = "Guaraná Fantástica" },
        new Product { Id = 25, Name = "NuNuCa Nuß-Nougat-Creme" },
        new Product { Id = 26, Name = "Gumbär Gummibärchen" },
        new Product { Id = 27, Name = "Schoggi Schokolade" },
        new Product { Id = 28, Name = "Rössle Sauerkraut" },
        new Product { Id = 29, Name = "Thüringer Rostbratwurst" },
        new Product { Id = 30, Name = "Nord-Ost Matjeshering" },
        new Product { Id = 31, Name = "Gorgonzola Telino" },
        new Product { Id = 32, Name = "Mascarpone Fabioli" },
        new Product { Id = 33, Name = "Geitost" },
        new Product { Id = 34, Name = "Sasquatch Ale" },
        new Product { Id = 35, Name = "Steeleye Stout" },
        new Product { Id = 36, Name = "Inlagd Sill" },
        new Product { Id = 37, Name = "Gravad lax" },
        new Product { Id = 38, Name = "Côte de Blaye" },
        new Product { Id = 39, Name = "Chartreuse verte" },
        new Product { Id = 40, Name = "Boston Crab Meat" },
        new Product { Id = 41, Name = "Jack's New England Clam Chowder" },
        new Product { Id = 42, Name = "Singaporean Hokkien Fried Mee" },
        new Product { Id = 43, Name = "Ipoh Coffee" },
        new Product { Id = 44, Name = "Gula Malacca" },
        new Product { Id = 45, Name = "Rogede sild" },
        new Product { Id = 46, Name = "Spegesild" },
        new Product { Id = 47, Name = "Zaanse koeken" },
        new Product { Id = 48, Name = "Chocolade" },
        new Product { Id = 49, Name = "Maxilaku" },
        new Product { Id = 50, Name = "Valkoinen suklaa" },
        new Product { Id = 51, Name = "Manjimup Dried Apples" },
        new Product { Id = 52, Name = "Filo Mix" },
        new Product { Id = 53, Name = "Perth Pasties" },
        new Product { Id = 54, Name = "Tourtière" },
        new Product { Id = 55, Name = "Pâté chinois" },
        new Product { Id = 56, Name = "Gnocchi di nonna Alice" },
        new Product { Id = 57, Name = "Ravioli Angelo" },
        new Product { Id = 58, Name = "Escargots de Bourgogne" },
        new Product { Id = 59, Name = "Raclette Courdavault" },
        new Product { Id = 60, Name = "Camembert Pierrot" },
        new Product { Id = 61, Name = "Sirop d'érable" },
        new Product { Id = 62, Name = "Tarte au sucre" },
        new Product { Id = 63, Name = "Vegie-spread" },
        new Product { Id = 64, Name = "Wimmers gute Semmelknödel" },
        new Product { Id = 65, Name = "Louisiana Fiery Hot Pepper Sauce" },
        new Product { Id = 66, Name = "Louisiana Hot Spiced Okra" },
        new Product { Id = 67, Name = "Laughing Lumberjack Lager" },
        new Product { Id = 68, Name = "Scottish Longbreads" },
        new Product { Id = 69, Name = "Gudbrandsdalsost" },
        new Product { Id = 70, Name = "Outback Lager" },
        new Product { Id = 71, Name = "Flotemysost" },
        new Product { Id = 72, Name = "Mozzarella di Giovanni" },
        new Product { Id = 73, Name = "Röd Kaviar" },
        new Product { Id = 74, Name = "Longlife Tofu" },
        new Product { Id = 75, Name = "Rhönbräu Klosterbier" },
        new Product { Id = 76, Name = "Lakkalikööri" },
        new Product { Id = 77, Name = "Original Frankfurter grüne Soße" }
    ];

    public static List<string> SimpleProducts = Products.Select(p => p.Name).ToList();
}
