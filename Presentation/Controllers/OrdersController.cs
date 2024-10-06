using Microsoft.AspNetCore.Mvc;
using Orders.Domain.Dtos;
using Orders.Presentation.Api;

namespace Orders.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<IEnumerable<OrdersStatusDto>>> GetOrders()
    {
        var orders = await _orderService.GetOrders();
        return Ok(orders);
    }

    [HttpGet("Get/{id:int}")]
    public async Task<ActionResult<OrdersStatusDto>> GetOrder(int id)
    {
        var order = await _orderService.GetOrder(id);
        if (order == null)
            return NotFound();

        return Ok(order);
    }
    
    [HttpPost("Create")]
    public async Task<ActionResult<int>> CreateOrder(OrderRequest request)
    {
        var result = await _orderService.CreateOrder(request);

        return Ok(result);
    }
    
    [HttpPut("Update")]
    public async Task<ActionResult<int>> ChangeOrder(OrderRequest request)
    {
        var result = await _orderService.ChangeOrder(request);
        return Ok(result);
    }

    [HttpDelete("Delete/{id:int}")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        await _orderService.DeleteOrder(id);

        return NoContent();
    }
}