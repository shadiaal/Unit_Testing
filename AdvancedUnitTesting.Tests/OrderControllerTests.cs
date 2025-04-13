using AdvancedUnitTesting.Controllers;
using AdvancedUnitTesting.Models;
using AdvancedUnitTesting.Serivces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace AdvancedUnitTesting.Tests
{
	public class OrderControllerTests
	{
		private Mock<IOrderRepository> _OrderRepositoryMock;
		private OrderController _OrderController;

		[SetUp]
		public void Setup()
		{
			_OrderRepositoryMock = new Mock<IOrderRepository>();
			_OrderController = new OrderController(_OrderRepositoryMock.Object);
		}

		[Test]
		public void GetOrderList_OrderList()
		{
			// Arrange
			var expectedOrders = GetOrdersData();
			_OrderRepositoryMock.Setup(x => x.GetAllOrders())
				.Returns(expectedOrders);

			// Act
			var result = _OrderController.GetAllOrders();

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count(), Is.EqualTo(expectedOrders.Count));
			Assert.That(result, Is.EquivalentTo(expectedOrders));
		}

		[Test]
		public void GetOrderByID_Order()
		{
			// Arrange
			var OrderList = GetOrdersData();
			_OrderRepositoryMock.Setup(x => x.GetOrderById(2))
				.Returns(OrderList[1]);

			// Act
			var OrderResult = _OrderController.GetOrderById(2);

			// Assert
			Assert.That(OrderResult, Is.Not.Null);
			Assert.That(OrderResult.OrderId, Is.EqualTo(OrderList[1].OrderId));
		}



		[Test]
		public void AddOrder_Order()
		{
			// Arrange
			var OrderList = GetOrdersData();
			_OrderRepositoryMock.Setup(x => x.AddOrder(OrderList[2]))
				.Returns(OrderList[2]);

			// Act
			var OrderResult = _OrderController.CreateOrder(OrderList[2]);

			// Assert
			Assert.That(OrderResult, Is.Not.Null);
			Assert.That(OrderResult.OrderId, Is.EqualTo(OrderList[2].OrderId));
		}

		[Test]
		public void UpdateOrder_ValidOrder_OrderIsUpdated()
		{
			// Arrange
			var orderList = GetOrdersData();
			var orderToUpdate = orderList[0];
			orderToUpdate.Product = "UpdatedName"; 

			_OrderRepositoryMock.Setup(x => x.UpdateOrder(orderToUpdate))
				.Returns(orderToUpdate)  
				.Verifiable();

			// Act
			var result = _OrderController.UpdateOrder(orderToUpdate.OrderId, orderToUpdate);

			// Assert
			Assert.That(result, Is.InstanceOf<Order>()); 
			var updatedOrder = result as Order;
			Assert.That(updatedOrder.Product, Is.EqualTo("UpdatedName")); 
			_OrderRepositoryMock.Verify(x => x.UpdateOrder(orderToUpdate), Times.Once); 
		}



		[Test]
		public void DeleteOrder_ExistingOrderId_OrderIsDeleted()
		{
			// Arrange
			var orderIdToDelete = 1;
			

			
			_OrderRepositoryMock.Setup(x => x.DeleteOrder(orderIdToDelete))
				.Returns(true);

			// Act
			var result = _OrderController.DeleteOrder(orderIdToDelete);

			// Assert
			Assert.That(result, Is.True); 
		}


		private List<Order> GetOrdersData()
		{
			return new List<Order>
	{
		new Order
		{
			OrderId = 1,
			UserId = 1,
			Product = "Laptop",
			Quantity = 2,
			Price = 1000.00m
		},
		new Order
		{
			OrderId = 2,
			UserId = 2,
			Product = "Smartphone",
			Quantity = 1,
			Price = 500.00m
		},
		new Order
		{
			OrderId = 3,
			UserId = 3,
			Product = "Headphones",
			Quantity = 3,
			Price = 150.00m
		}
	};
		}

	}
}


