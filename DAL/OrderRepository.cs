using Microsoft.EntityFrameworkCore;
using ORM_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORM_CRUD.DAL
{
    internal class OrderRepository
    {
        private readonly DataContext _context;
        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _context.Orders.AsEnumerable();
        }

        public Order GetOrderById(int id)
        {
            return _context.Orders.Find(id);
        }

        public IEnumerable<Order> GetOrdersByFilter(DateTime? startDate, DateTime? endDate, string status, int? productId)
        {
            var orders = _context.Orders.AsEnumerable();

            if (startDate.HasValue)
            {
                orders = orders.Where(o => o.CreatedDate >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                orders = orders.Where(o => o.UpdatedDate <= endDate.Value);
            }

            if (!string.IsNullOrEmpty(status))
            {
                orders = orders.Where(o => o.Status == status);
            }

            if (productId.HasValue)
            {
                orders = orders.Where(o => o.ProductId == productId.Value);
            }

            return orders;
        }

        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            var order = _context.Orders.Find(id);
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        public void DeleteOrdersByFilter(DateTime? startDate, DateTime? endDate, string status, int? productId)
        {
            var orders = GetOrdersByFilter(startDate, endDate, status, productId);

            _context.Orders.RemoveRange(orders);
            _context.SaveChanges();
        }
    }
}
