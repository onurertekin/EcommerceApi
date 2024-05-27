using Contract.Request.Categories;
using Contract.Request.OrderItem;
using Contract.Response.OrderItem;
using DatabaseModel.Entities;
using DomainService.Operations;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [ApiController]
    [Route("ecommerce-api/orderItem")]
    public class OrderItemsController
    {
        private readonly OrderItemOperations orderItemOperations;
        public OrderItemsController(OrderItemOperations orderItemOperations)
        {
            this.orderItemOperations = orderItemOperations;
        }

        [HttpGet]
        public ActionResult<SearchOrderItemResponse> Search([FromQuery] SearchOrderItemRequest request)
        {
            var orderItems = orderItemOperations.Search(request.orderId, request.productId, request.quantity, request.unitPrice, request.sortBy, request.sortDirection, request.pageSize, request.pageNumber, out int totalCount);

            SearchOrderItemResponse response = new SearchOrderItemResponse();
            foreach (var orderItem in orderItems)
            {
                response.orderItems.Add(new SearchOrderItemResponse.OrderItem()
                {
                    id = orderItem.Id,
                    orderId = orderItem.OrderId,
                    productId = orderItem.ProductId,
                    quantity = orderItem.Quantity,
                    unitPrice = orderItem.UnitPrice,
                });
            }
            response.totalCount = totalCount;
            return new JsonResult(response);
        }

        [HttpGet("{id}")]
        public ActionResult<GetSingleOrderItemResponse> GetSingle(int id)
        {
            var orderItem = orderItemOperations.GetSingle(id);
            GetSingleOrderItemResponse response = new GetSingleOrderItemResponse();
            response.id = orderItem.Id;
            response.productId = orderItem.ProductId;
            response.quantity = orderItem.Quantity;
            response.unitPrice = orderItem.UnitPrice;
            response.orderId = orderItem.OrderId;

            return new JsonResult(response);
        }

        [HttpPost]
        public void Create([FromBody] CreateOrderItemRequest request)
        {
            orderItemOperations.Create(request.orderId, request.productId, request.quantity, request.unitPrice);
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] UpdateOrderItemRequest request)
        {
            orderItemOperations.Update(id, request.orderId, request.productId, request.quantity, request.unitPrice);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            orderItemOperations.Delete(id);
        }

    }
}
