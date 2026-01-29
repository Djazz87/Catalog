namespace Catalog.Models;

public class Product
{
    public int ProductId { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    public decimal Price { get; set; }
    
    public Manufacturer Manufacturer { get; set; }
   
}