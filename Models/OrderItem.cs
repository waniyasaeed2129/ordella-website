namespace Ordella_deliverable2.Models;
public class OrderItem
{
 public int Id {get;set;} public int OrderId {get;set;} public CustomerOrder? Order {get;set;}
 public int ProductId {get;set;} public Product? Product {get;set;}
 public string ProductName {get;set;} = ""; public decimal UnitPrice {get;set;} public int Quantity {get;set;}
}
