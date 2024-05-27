using DatabaseModel;
using DatabaseModel.Entities;
using DomainService.Exceptions;
using DomainService.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Operations
{
    public class OrderOperations
    {
        private readonly MainDbContext mainDbContext;
        public OrderOperations(MainDbContext mainDbContext)
        {
            this.mainDbContext = mainDbContext;
        }

        public IList<Order> Search(int? customerId, int? addressId, DateTime? orderDate, int? orderStatus, string sortBy, string sortDirection, int pageSize, int pageNumber, out int totalCount)
        {
            var query = mainDbContext.Orders.AsQueryable();

            if (customerId != 0 && customerId != null)
                query = query.Where(x => x.CustomerId == customerId);

            if (addressId != 0 && addressId != null)
                query = query.Where(x => x.AddressId == addressId);

            if (orderStatus != 0 && orderStatus != null)
                query = query.Where(x => x.OrderStatus == orderStatus);

            if (orderDate != DateTime.MinValue && orderDate != null)
                query = query.Where(x => x.OrderDate == orderDate);

            return query.GetPagedAndSorted(pageNumber, pageSize, sortDirection, sortBy, out totalCount);
        }

        public Order GetSingle(int id)
        {
            var order = mainDbContext.Orders.Where(x => x.Id == id).SingleOrDefault();

            if (order == null)
                throw new BusinessException(404, "Sipariş bulunamadı");

            return order;
        }

        public void Create(int customerId, int addressId, DateTime orderDate, int orderStatus)
        {
            Order order = new Order();
            order.CustomerId = customerId;
            order.AddressId = addressId;
            order.OrderStatus = orderStatus;
            order.OrderDate = orderDate;

            mainDbContext.Orders.Add(order);
            mainDbContext.SaveChanges();
        }
        public void Update(int id, int customerId, int addressId, DateTime orderDate, int orderStatus)
        {
            #region Validation
            var order = mainDbContext.Orders.Where(x => x.Id == id).SingleOrDefault();
            if (order == null)
                throw new BusinessException(404, "Sipariş bulunamadı.");
            #endregion
            order.CustomerId = customerId;
            order.AddressId = addressId;
            order.OrderDate = orderDate;
            order.OrderStatus = orderStatus;

            mainDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var order = mainDbContext.Orders.Where(x => x.Id == id).SingleOrDefault();
            if (order == null)
                throw new BusinessException(404, "Sipariş bulunamadı.");

            mainDbContext.Orders.Remove(order);
            mainDbContext.SaveChanges();
        }
    }
}
