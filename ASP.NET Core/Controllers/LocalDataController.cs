using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using ASP_NET_Core.Models;

namespace ASP_NET_Core.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocalDataController : ControllerBase {
    [HttpGet("GetCategories")]
    public object GetCategories(DataSourceLoadOptions loadOptions) {
        return DataSourceLoader.Load(DemoData.Categories, loadOptions);
    }

    [HttpGet("GetProducts")]
    public object GetProducts(DataSourceLoadOptions loadOptions) {
        return DataSourceLoader.Load(DemoData.Products, loadOptions);
    }

    [HttpGet("GetSimpleProducts")]
    public object GetSimpleProducts(DataSourceLoadOptions loadOptions) {
        return DataSourceLoader.Load(DemoData.SimpleProducts, loadOptions);
    }
}
