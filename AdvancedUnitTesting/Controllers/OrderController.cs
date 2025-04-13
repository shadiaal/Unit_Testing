using AdvancedUnitTesting.Models;
using AdvancedUnitTesting.Serivces;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedUnitTesting.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class OrderController : ControllerBase
	{
		private readonly IOrderRepository _orderRepository;

		public OrderController(IOrderRepository orderRepository)
		{
			_orderRepository = orderRepository;
		}

		[HttpGet("getorderbyid")]
		public Order GetOrderById(int id)
		{
			return _orderRepository.GetOrderById(id);
		}

		[HttpGet("orderlist")]
		public IEnumerable<Order> GetAllOrders()
		{
			return _orderRepository.GetAllOrders();
			
		}

		[HttpPost("createorder")]
		public Order CreateOrder(Order Order)
		{
			return _orderRepository.AddOrder(Order);
			
		}

		[HttpPut("updateorder")]
		public Order UpdateOrder(int id, Order Order)
		{


			return _orderRepository.UpdateOrder(Order);
			
		}

		[HttpDelete("deleteorder")]
		public bool DeleteOrder(int id)
		{
			return _orderRepository.DeleteOrder(id);
			
		}
	}
}
