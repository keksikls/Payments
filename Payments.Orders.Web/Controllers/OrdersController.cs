using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Payments.Orders.Application.Abstractions;
using Payments.Orders.Application.Models.Orders;
using Payments.Orders.Domain;
using System.Text.Json;

namespace Payments.Orders.Web.Controllers
{
    [Route("api/orders")]
    public class OrdersController(IOrdersService orders, ILogger<OrdersController> logger, OrdersDbContext context) : ApiBaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderDto request)
        {
            try
            {
                logger.LogInformation($"Method api/orders Create started. Request: {JsonSerializer.Serialize(request)}");

                var result = await orders.Create(request);

                logger.LogInformation($"Method api/orders Create finished. Request: {JsonSerializer.Serialize(request)}" +
                                      $"Response: {JsonSerializer.Serialize(result)}");

                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllOrder()
        {
            try
            {
                logger.LogInformation($"Method api/orders Create started.");

                var result = await orders.GetAll();

                logger.LogInformation($"Method api/orders finished. Result count: {result.Count}");

                return Ok(new { orders = result });

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{orderId:long}")]
        public async Task<IActionResult> GetById(long orderId)
        {
            try
            {
                logger.LogInformation($"Method api/orders/{orderId} Create started.");

                var result = await orders.GetById(orderId);

                logger.LogInformation($"Method api/orders{orderId} finished." +
                                          $"Response: {JsonSerializer.Serialize(orderId)}");

                return Ok(result);
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpGet("customers/{customerId:long}")]
        public async Task<IActionResult> GetByUser(long customerId)
        {
            try
            {
                logger.LogInformation($"Method api/orders/custumers/{customerId} GetByUser started.");

                var result = await orders.GetByUser(customerId);

                logger.LogInformation($"Method api/orders/customers/{customerId} GetByUser finished.");

                return Ok(new { orders = result });
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost("{orderId:long}/reject")]
        public async Task<IActionResult> Reject(long orderId)
        {
            await orders.Reject(orderId);
            return Ok();
        }
    }
}