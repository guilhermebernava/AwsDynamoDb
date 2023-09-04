using Microsoft.AspNetCore.Mvc;
using Services.Dtos;
using Services.Services;

namespace ApiDynamoDb.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{

    [HttpGet("ById")]
    public async Task<IActionResult> GetById([FromServices] IProductGetByIdServices services, [FromQuery] string id)
    {
        var result = await services.ExecuteAsync(id);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromServices] IProductGetAllServices services)
    {
        var products = await services.ExecuteAsync();
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromServices] IProductCreateServices services, [FromBody] ProductDto dto)
    {
        var result = await services.ExecuteAsync(dto);
        if (!result) return BadRequest();
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromServices] IProductUpdateServices services, [FromBody] ProductUpdateDto dto)
    {
        var result = await services.ExecuteAsync(dto);
        if (!result) return BadRequest();
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromServices] IProductDeleteServices services, [FromBody] string id)
    {
        var result = await services.ExecuteAsync(id);
        if (!result) return BadRequest();
        return Ok();
    }
}