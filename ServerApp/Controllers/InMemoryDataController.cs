using Microsoft.AspNetCore.Mvc;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using ServerApp.Models;

namespace ServerApp.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class InMemoryDataController : ControllerBase
  {
    [HttpGet("GetCategories")]
    public object GetCategories(DataSourceLoadOptions loadOptions) {
      var query = InMemoryDataContext.Categories.AsQueryable()
          // use the extension method to register custom filtering logic
          .RegisterFilterFor(c => c.Products, p => p.ProductName);
      return DataSourceLoader.Load(query, loadOptions);
    }

    [HttpGet("GetProducts")]
    public object GetProducts(DataSourceLoadOptions loadOptions) {
      return DataSourceLoader.Load(InMemoryDataContext.Products, loadOptions);
    }
  }
}
