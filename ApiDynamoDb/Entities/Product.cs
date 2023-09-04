using Amazon.DynamoDBv2.DataModel;

namespace ApiDynamoDb.Entities;

[DynamoDBTable("products")]
public class Product
{
    public Product()
    {
        
    }
    public Product(string name, string price)
    {
        Id = Guid.NewGuid().ToString();
        Name = name;
        Price = price;
    }

    [DynamoDBHashKey("Id")]
    public string Id { get; set; }
    [DynamoDBHashKey("Name")]
    public string Name { get; set; }
    [DynamoDBHashKey("Price")]
    public string Price { get; set; }
}
