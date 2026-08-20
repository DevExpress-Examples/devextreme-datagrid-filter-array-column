using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using ServerApp;
using ServerApp.Models;
using System.Collections;
using Xunit;

namespace ServerApp.Tests
{
  public class FilterByCollectionPropertyHelperTests
  {
    public FilterByCollectionPropertyHelperTests() {
      FilterByCollectionPropertyHelper.ResetForTests();
    }

    static IQueryable<Category> BuildData() {
      var categories = new List<Category> {
        new Category {
          CategoryId = 1,
          CategoryName = "Beverages",
          Products = new List<Product> {
            new Product { ProductId = 1, ProductName = "Chai" },
            new Product { ProductId = 2, ProductName = "Chang" }
          }
        },
        new Category {
          CategoryId = 2,
          CategoryName = "Condiments",
          Products = new List<Product> {
            new Product { ProductId = 3, ProductName = "Aniseed Syrup" }
          }
        },
        new Category {
          CategoryId = 3,
          CategoryName = "Empty Category",
          Products = new List<Product>()
        }
      };
      return categories.AsQueryable();
    }

    static DataSourceLoadOptions BuildLoadOptions(IList filter) =>
      new DataSourceLoadOptions { Filter = filter };

    static List<Category> LoadCategories(IQueryable<Category> query, IList filter) {
      var loadOptions = BuildLoadOptions(filter);
      var result = DataSourceLoader.Load(query, loadOptions);
      return result.data.Cast<Category>().ToList();
    }

    [Fact]
    public void UnregisteredProperty_FallsBackToDefaultFiltering() {
      var query = BuildData();
      var items = LoadCategories(query, new object[] { "Products", "contains", "Chai" });
      Assert.Empty(items);
    }

    [Fact]
    public void Contains_ReturnsMatchingParent() {
      var query = BuildData().RegisterFilterFor(c => c.Products, p => p.ProductName);
      var items = LoadCategories(query, new object[] { "Products", "contains", "Chai" });
      Assert.Single(items);
      Assert.Equal("Beverages", items[0].CategoryName);
    }

    [Fact]
    public void Contains_NoMatch_ReturnsEmpty() {
      var query = BuildData().RegisterFilterFor(c => c.Products, p => p.ProductName);
      var items = LoadCategories(query, new object[] { "Products", "contains", "NoSuchProduct" });
      Assert.Empty(items);
    }

    [Fact]
    public void StartsWith_MatchesCorrectCategory() {
      var query = BuildData().RegisterFilterFor(c => c.Products, p => p.ProductName);
      var items = LoadCategories(query, new object[] { "Products", "startswith", "Ani" });
      Assert.Single(items);
      Assert.Equal("Condiments", items[0].CategoryName);
    }

    [Fact]
    public void EndsWith_MatchesCorrectCategory() {
      var query = BuildData().RegisterFilterFor(c => c.Products, p => p.ProductName);
      var items = LoadCategories(query, new object[] { "Products", "endswith", "Syrup" });
      Assert.Single(items);
      Assert.Equal("Condiments", items[0].CategoryName);
    }

    [Fact]
    public void Equals_MatchesExactValueOnly() {
      var query = BuildData().RegisterFilterFor(c => c.Products, p => p.ProductName);
      var items = LoadCategories(query, new object[] { "Products", "=", "Chai" });
      Assert.Single(items);
      Assert.Equal("Beverages", items[0].CategoryName);
    }

    [Fact]
    public void EmptyCollection_NeverMatches() {
      var query = BuildData().RegisterFilterFor(c => c.Products, p => p.ProductName);
      var items = LoadCategories(query, new object[] { "Products", "contains", "anything" });
      Assert.DoesNotContain(items, c => c.CategoryName == "Empty Category");
    }
  }
}
