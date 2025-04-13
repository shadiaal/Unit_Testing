using AdvancedUnitTesting.Models;

namespace AdvancedUnitTesting.Serivces
{
	public interface IOrderRepository
	{
		public Order AddOrder(Order Order);
		public Order GetOrderById(int id);
		public IEnumerable<Order> GetAllOrders();
		public Order UpdateOrder(Order Order);
		public bool DeleteOrder(int Id);
	}
}
