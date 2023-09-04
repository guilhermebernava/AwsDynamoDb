namespace ApiDynamoDb.Dtos;

public record ProductDto(string Name,string Price);

public record ProductUpdateDto(string Id,string Name, string Price);
