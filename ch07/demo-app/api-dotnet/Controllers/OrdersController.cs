using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using api_dotnet.Models;

namespace api_dotnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> logger;
        private readonly DataContext dataContext;

        public OrdersController(ILogger<OrdersController> logger, DataContext dataContext)
        {
            this.logger = logger;
            this.dataContext = dataContext;
        }

        [HttpGet]
        public IEnumerable<Order> Get([FromQuery]OrderStatus? status)
        {
            logger.LogInformation($"Getting all orders by status {status}");
            return status == null 
                ? dataContext.Orders.ToList() 
                : dataContext.Orders
                    .Where(o => o.Status == status)
                    .ToList();
        }

        [HttpPost]
        public void AddOrder(Order order)
        {
            logger.LogInformation($"Getting new order: {order}");
            dataContext.Orders.Add(order);
            dataContext.SaveChanges();
        }
    }
}