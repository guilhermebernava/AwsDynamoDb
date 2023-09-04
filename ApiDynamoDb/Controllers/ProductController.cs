using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using ApiDynamoDb.Dtos;
using ApiDynamoDb.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiDynamoDb.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IAmazonDynamoDB _dynamoDbClient;

    public ProductController(IAmazonDynamoDB dynamoDbClient)
    {
        _dynamoDbClient = dynamoDbClient;
    }

    [HttpGet]
    public async Task<List<Product>> GetAll()
    {
        var queryResponse = await _dynamoDbClient.ScanAsync(new ScanRequest() { TableName = "products" });
        return queryResponse.Items.Select(item =>
        new Product
        {
            Id = item["Id"].S,
            Name = item["Name"].S,
            Price = item["Price"].S
        }).ToList();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductDto dto)
    {
        var productId = Guid.NewGuid().ToString();
        var newItem = new Dictionary<string, AttributeValue>
        {
            ["Id"] = new AttributeValue(s: productId),
            ["Name"] = new AttributeValue(s: dto.Name),
            ["Price"] = new AttributeValue(s: dto.Price)
        };

        var response = await _dynamoDbClient.PutItemAsync(new PutItemRequest
        {
            TableName = "products",
            Item = newItem
        });

        return response.HttpStatusCode == System.Net.HttpStatusCode.OK ? Ok() : BadRequest(response.ResponseMetadata);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] ProductUpdateDto dto)
    {

        var data = new Dictionary<string, AttributeValueUpdate>
        {
            ["Name"] = new AttributeValueUpdate(new AttributeValue(s: dto.Name), new AttributeAction("PUT")),
            ["Price"] = new AttributeValueUpdate(new AttributeValue(s: dto.Price), new AttributeAction("PUT")),
        };

        var keys = new Dictionary<string, AttributeValue>
        {
            ["Id"] = new AttributeValue(s: dto.Id),
        };

        var response = await _dynamoDbClient.UpdateItemAsync("products", keys, data);

        return response.HttpStatusCode == System.Net.HttpStatusCode.OK ? Ok() : BadRequest(response.ResponseMetadata);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] string id)
    {
        var keys = new Dictionary<string, AttributeValue>
        {
            ["Id"] = new AttributeValue(s: id),
        };

        var response = await _dynamoDbClient.DeleteItemAsync("products", keys);

        return response.HttpStatusCode == System.Net.HttpStatusCode.OK ? Ok() : BadRequest(response.ResponseMetadata);
    }
}