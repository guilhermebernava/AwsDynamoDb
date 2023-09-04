using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Domain.Entities;
using Domain.Repositories;
using System.Net;
using System.Text.Json;

namespace Infra.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly string _table = "products";
    private readonly IAmazonDynamoDB _dynamoDbClient;

    public ProductRepository(IAmazonDynamoDB dynamoDbClient)
    {
        _dynamoDbClient = dynamoDbClient;
    }

    public async Task<bool> CreateAsync(Product product)
    {

        product.Id ??= Guid.NewGuid().ToString();

        var item = Document.FromJson(JsonSerializer.Serialize(product)).ToAttributeMap();

        var response = await _dynamoDbClient.PutItemAsync(new PutItemRequest
        {
            TableName = _table,
            Item = item
        });

        return response.HttpStatusCode == HttpStatusCode.OK;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var keys = new Dictionary<string, AttributeValue>
        {
            ["Id"] = new AttributeValue(s: id),
        };

        var response = await _dynamoDbClient.DeleteItemAsync("products", keys);

        return response.HttpStatusCode == HttpStatusCode.OK;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        var queryResponse = await _dynamoDbClient.ScanAsync(new ScanRequest() { TableName = _table });
        List<Product> products = new();

        queryResponse.Items.ForEach(item =>
        {
            var product = JsonSerializer.Deserialize<Product>(Document.FromAttributeMap(item).ToJson()) ?? throw new Exception("Error in deserialize json");
            products.Add(product);
        });
        

        return products;
    }

    public async Task<Product> GetByIdAsync(string id)
    {
        var request = new GetItemRequest
        {
            TableName = _table,
            Key = new Dictionary<string, AttributeValue>
                    {
                        { "Id", new AttributeValue { S = id } }
                    }
        };

        var response = await _dynamoDbClient.GetItemAsync(request) ?? throw new Exception("Not found any Product");

        var product = JsonSerializer.Deserialize<Product>(Document.FromAttributeMap(response.Item).ToJson());

        if (product?.Id == null) throw new Exception("Error in deserialize json");

        return product ?? throw new Exception("Error in deserialize json");
    }

    public async Task<bool> UpdateAsync(Product product) => await CreateAsync(product);

}
