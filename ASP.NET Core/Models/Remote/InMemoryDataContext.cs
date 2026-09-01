using System.Collections.Generic;

namespace ASP_NET_Core.Models.Remote {
  public static class InMemoryDataContext
  {
    public static List<Product> Products { get; set; } = new List<Product> {
      new() { ProductId = 1, ProductName = "Chai" },
      new() { ProductId = 2, ProductName = "Chang" },
      new() { ProductId = 3, ProductName = "Aniseed Syrup" },
      new() { ProductId = 4, ProductName = "Chef Anton's Cajun Seasoning" },
      new() { ProductId = 5, ProductName = "Chef Anton's Gumbo Mix" },
      new() { ProductId = 6, ProductName = "Grandma's Boysenberry Spread" },
      new() { ProductId = 7, ProductName = "Uncle Bob's Organic Dried Pears" },
      new() { ProductId = 8, ProductName = "Northwoods Cranberry Sauce" },
      new() { ProductId = 9, ProductName = "Mishi Kobe Niku" },
      new() { ProductId = 10, ProductName = "Ikura" },
      new() { ProductId = 11, ProductName = "Queso Cabrales" },
      new() { ProductId = 12, ProductName = "Queso Manchego La Pastora" },
      new() { ProductId = 13, ProductName = "Konbu" },
      new() { ProductId = 14, ProductName = "Tofu" },
      new() { ProductId = 15, ProductName = "Genen Shouyu" },
      new() { ProductId = 16, ProductName = "Pavlova" },
      new() { ProductId = 17, ProductName = "Alice Mutton" },
      new() { ProductId = 18, ProductName = "Carnarvon Tigers" },
      new() { ProductId = 19, ProductName = "Teatime Chocolate Biscuits" },
      new() { ProductId = 20, ProductName = "Sir Rodney's Marmalade" },
      new() { ProductId = 21, ProductName = "Sir Rodney's Scones" },
      new() { ProductId = 22, ProductName = "Gustaf's Knäckebröd" },
      new() { ProductId = 23, ProductName = "Tunnbröd" },
      new() { ProductId = 24, ProductName = "Guaraná Fantástica" },
      new() { ProductId = 25, ProductName = "NuNuCa Nuß-Nougat-Creme" },
      new() { ProductId = 26, ProductName = "Gumbär Gummibärchen" },
      new() { ProductId = 27, ProductName = "Schoggi Schokolade" },
      new() { ProductId = 28, ProductName = "Rössle Sauerkraut" },
      new() { ProductId = 29, ProductName = "Thüringer Rostbratwurst" },
      new() { ProductId = 30, ProductName = "Nord-Ost Matjeshering" },
      new() { ProductId = 31, ProductName = "Gorgonzola Telino" },
      new() { ProductId = 32, ProductName = "Mascarpone Fabioli" },
      new() { ProductId = 33, ProductName = "Geitost" },
      new() { ProductId = 34, ProductName = "Sasquatch Ale" },
      new() { ProductId = 35, ProductName = "Steeleye Stout" },
      new() { ProductId = 36, ProductName = "Inlagd Sill" },
      new() { ProductId = 37, ProductName = "Gravad lax" },
      new() { ProductId = 38, ProductName = "Côte de Blaye" },
      new() { ProductId = 39, ProductName = "Chartreuse verte" },
      new() { ProductId = 40, ProductName = "Boston Crab Meat" },
      new() { ProductId = 41, ProductName = "Jack's New England Clam Chowder" },
      new() { ProductId = 42, ProductName = "Singaporean Hokkien Fried Mee" },
      new() { ProductId = 43, ProductName = "Ipoh Coffee" },
      new() { ProductId = 44, ProductName = "Gula Malacca" },
      new() { ProductId = 45, ProductName = "Rogede sild" },
      new() { ProductId = 46, ProductName = "Spegesild" },
      new() { ProductId = 47, ProductName = "Zaanse koeken" },
      new() { ProductId = 48, ProductName = "Chocolade" },
      new() { ProductId = 49, ProductName = "Maxilaku" },
      new() { ProductId = 50, ProductName = "Valkoinen suklaa" },
      new() { ProductId = 51, ProductName = "Manjimup Dried Apples" },
      new() { ProductId = 52, ProductName = "Filo Mix" },
      new() { ProductId = 53, ProductName = "Perth Pasties" },
      new() { ProductId = 54, ProductName = "Tourtière" },
      new() { ProductId = 55, ProductName = "Pâté chinois" },
      new() { ProductId = 56, ProductName = "Gnocchi di nonna Alice" },
      new() { ProductId = 57, ProductName = "Ravioli Angelo" },
      new() { ProductId = 58, ProductName = "Escargots de Bourgogne" },
      new() { ProductId = 59, ProductName = "Raclette Courdavault" },
      new() { ProductId = 60, ProductName = "Camembert Pierrot" },
      new() { ProductId = 61, ProductName = "Sirop d'érable" },
      new() { ProductId = 62, ProductName = "Tarte au sucre" },
      new() { ProductId = 63, ProductName = "Vegie-spread" },
      new() { ProductId = 64, ProductName = "Wimmers gute Semmelknödel" },
      new() { ProductId = 65, ProductName = "Louisiana Fiery Hot Pepper Sauce" },
      new() { ProductId = 66, ProductName = "Louisiana Hot Spiced Okra" },
      new() { ProductId = 67, ProductName = "Laughing Lumberjack Lager" },
      new() { ProductId = 68, ProductName = "Scottish Longbreads" },
      new() { ProductId = 69, ProductName = "Gudbrandsdalsost" },
      new() { ProductId = 70, ProductName = "Outback Lager" },
      new() { ProductId = 71, ProductName = "Flotemysost" },
      new() { ProductId = 72, ProductName = "Mozzarella di Giovanni" },
      new() { ProductId = 73, ProductName = "Röd Kaviar" },
      new() { ProductId = 74, ProductName = "Longlife Tofu" },
      new() { ProductId = 75, ProductName = "Rhönbräu Klosterbier" },
      new() { ProductId = 76, ProductName = "Lakkalikööri" },
      new() { ProductId = 77, ProductName = "Original Frankfurter grüne Soße" },
    };

    public static List<Category> Categories { get; set; } = new List<Category>() {
      new Category {
        CategoryId = 1,
        CategoryName = "Beverages",
        Description = "Soft drinks, coffees, teas, beers, and ales",
        Products = new List<Product>() {
          Products[0],
          Products[1],
          Products[23],
          Products[33],
          Products[34],
          Products[37],
          Products[38],
          Products[42],
          Products[66],
          Products[69],
          Products[74],
          Products[75]
        }
      },
      new Category {
        CategoryId = 2,
        CategoryName = "Condiments",
        Description = "Sweet and savory sauces, relishes, spreads, and seasonings",
        Products = new List<Product>() {
          Products[2],
          Products[3],
          Products[4],
          Products[5],
          Products[7],
          Products[14],
          Products[43],
          Products[60],
          Products[62],
          Products[64],
          Products[65],
          Products[76]
        }
      },
      new Category {
        CategoryId = 3,
        CategoryName = "Confections",
        Description = "Desserts, candies, and sweet breads",
        Products = new List<Product>() {
          Products[15],
          Products[18],
          Products[19],
          Products[20],
          Products[24],
          Products[25],
          Products[26],
          Products[46],
          Products[47],
          Products[48],
          Products[49],
          Products[61],
          Products[67]
        }
      },
      new Category {
        CategoryId = 4,
        CategoryName = "Dairy Products",
        Description = "Cheeses",
        Products = new List<Product>() {
          Products[10],
          Products[11],
          Products[30],
          Products[31],
          Products[32],
          Products[58],
          Products[59],
          Products[68],
          Products[70],
          Products[71]
        }
      },
      new Category {
        CategoryId = 5,
        CategoryName = "Grains/Cereals",
        Description = "Breads, crackers, pasta, and cereal",
        Products = new List<Product>() {
          Products[21],
          Products[22],
          Products[41],
          Products[51],
          Products[55],
          Products[56],
          Products[63]
        }
      },
      new Category {
        CategoryId = 6,
        CategoryName = "Meat/Poultry",
        Description = "Prepared meats",
        Products = new List<Product>() {
          Products[8],
          Products[16],
          Products[28],
          Products[52],
          Products[53],
          Products[54]
        }
      },
      new Category {
        CategoryId = 7,
        CategoryName = "Produce",
        Description = "Dried fruit and bean curd",
        Products = new List<Product>() {
          Products[6],
          Products[13],
          Products[27],
          Products[50],
          Products[73]
        }
      },
      new Category {
        CategoryId = 8,
        CategoryName = "Seafood",
        Description = "Seaweed and fish",
        Products = new List<Product>() {
          Products[9],
          Products[12],
          Products[17],
          Products[29],
          Products[35],
          Products[36],
          Products[39],
          Products[40],
          Products[44],
          Products[45],
          Products[57],
          Products[72]
        }
      },
    };
  }
}
