using AdvancedUnitTesting.Data;
using AdvancedUnitTesting.Models;

namespace AdvancedUnitTesting.Serivces
{
	public class OrderRepository : IOrderRepository
	{
		private readonly AppDbContext _context;

		public OrderRepository(AppDbContext context)
		{
			_context = context;
		}
	

		//Read
		public IEnumerable<Order> GetAllOrders()
		{
			return _context.Orders.ToList();
		}
		public Order GetOrderById(int id)
		{
			return _context.Orders.Where(x => x.OrderId == id).FirstOrDefault();
		}
		//Create
		public Order AddOrder(Order Order)
		{
			var result = _context.Orders.Add(Order);
			_context.SaveChanges();
			return result.Entity;
		}
		//Update
		public Order UpdateOrder(Order Order)
		{
			var result = _context.Orders.Update(Order);
			_context.SaveChanges();
			return result.Entity;
		}
		//Delete
		public bool DeleteOrder(int Id)
		{
			var filteredData = _context.Orders.Where(x => x.OrderId == Id).FirstOrDefault();
			var result = _context.Remove(filteredData);
			_context.SaveChanges();
			return result != null ? true : false;
		}
	}

}
