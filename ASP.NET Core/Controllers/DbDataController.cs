using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using ASP_NET_Core.Models.Remote;

namespace ASP_NET_Core.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class DbDataController : ControllerBase
  {
    [HttpGet("GetCategories")]
    public object GetCategories(DataSourceLoadOptions loadOptions) {
      NorthwindContext northwind = new NorthwindContext();
      var query = northwind.Categories.Include(c => c.Products)
          .Select(c => new { c.CategoryId, c.CategoryName, c.Description, c.Products })
          // use the extension method to register custom filtering logic
          .RegisterFilterFor(c => c.Products, p => p.ProductName);
      return DataSourceLoader.Load(query, loadOptions);
    }

    [HttpGet("GetProducts")]
    public object GetProducts(DataSourceLoadOptions loadOptions) {
      NorthwindContext northwind = new NorthwindContext();
      return DataSourceLoader.Load(northwind.Products, loadOptions);
    }
  }
}
