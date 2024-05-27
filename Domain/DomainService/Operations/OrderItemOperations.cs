using Contract.Request;
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
    public class OrderItemOperations
    {
        private readonly MainDbContext mainDbContext;
        public OrderItemOperations(MainDbContext mainDbContext)
        {
            this.mainDbContext = mainDbContext;
        }

        public IList<OrderItem> Search(int orderId, int productId, int quantity, decimal unitPrice, string sortBy, string sortDirection, int pageSize, int pageNumber, out int totalCount)
        {
            var query = mainDbContext.OrderItems.AsQueryable();

            if (orderId != 0 && orderId != null)
                query = query.Where(x => x.OrderId == orderId);

            if (productId != 0 && productId != null)
                query = query.Where(x => x.ProductId == productId);

            if (quantity != 0 && quantity != null)
                query = query.Where(x => x.Quantity == quantity);

            if (unitPrice != 0 && unitPrice != null)
                query = query.Where(x => x.UnitPrice == unitPrice);

            return query.GetPagedAndSorted(pageNumber, pageSize, sortDirection, sortBy, out totalCount);
        }

        public OrderItem GetSingle(int id)
        {
            var orderItem = mainDbContext.OrderItems.Where(x => x.Id == id).SingleOrDefault();

            if (orderItem == null)
                throw new BusinessException(404, "Sipariş öğesi bulunamadı.");

            return orderItem;
        }

        public void Create(int orderId, int productId, int quantity, decimal unitPrice)
        {
            OrderItem orderItem = new OrderItem();
            orderItem.OrderId = orderId;
            orderItem.ProductId = productId;
            orderItem.Quantity = quantity;
            orderItem.UnitPrice = unitPrice;

            mainDbContext.OrderItems.Add(orderItem);
            mainDbContext.SaveChanges();
        }

        public void Update(int id, int orderId, int productId, int quantity, decimal unitPrice)
        {
            #region Validations
            var orderItem = mainDbContext.OrderItems.Where(x => x.Id == id).SingleOrDefault();
            if (orderItem == null)
                throw new BusinessException(404, "Sipariş öğesi bulunamadı.");
            #endregion

            orderItem.OrderId = orderId;
            orderItem.ProductId = productId;
            orderItem.Quantity = quantity;
            orderItem.UnitPrice = unitPrice;
            mainDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var orderItem = mainDbContext.OrderItems.Where(x => x.Id == id).SingleOrDefault();
            if (orderItem == null)
                throw new BusinessException(404, "Sipariş öğesi bulunamadı.");

            mainDbContext.Remove(orderItem);
            mainDbContext.SaveChanges();
        }
    }
}
