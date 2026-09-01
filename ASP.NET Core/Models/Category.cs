using System.Collections.Generic;

namespace ASP_NET_Core.Models;

public class Category {
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }
    public int[] Products { get; set; }
    public string[] SimpleProducts { get; set; }
}

public class Product {
    public int Id { get; set; }
    public string Name { get; set; }
}
