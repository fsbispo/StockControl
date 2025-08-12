using Microsoft.AspNetCore.Mvc;
using StockControl.Application.Commands;
using StockControl.Application.Handlers;
using StockControl.Domain.Commands.Products;
using StockControl.Domain.Handlers.Products;

namespace StockControl.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly CreateProductHandler _createHandler;
    private readonly AddStockHandler _addStockHandler;
    private readonly RemoveStockHandler _removeStockHandler;

    public ProductsController(
        CreateProductHandler createHandler,
        AddStockHandler addStockHandler,
        RemoveStockHandler removeStockHandler)
    {
        _createHandler = createHandler;
        _addStockHandler = addStockHandler;
        _removeStockHandler = removeStockHandler;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
    {
        await _createHandler.Handle(command);
        return Ok();
    }

    [HttpPost("add-stock")]
    public async Task<IActionResult> AddStock([FromBody] AddStockCommand command)
    {
        await _addStockHandler.Handle(command);
        return Ok();
    }

    [HttpPost("remove-stock")]
    public async Task<IActionResult> RemoveStock([FromBody] RemoveStockCommand command)
    {
        await _removeStockHandler.Handle(command);
        return Ok();
    }
}
