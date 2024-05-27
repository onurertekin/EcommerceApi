using Contract.Request.Orders;
using Contract.Response.Orders;
using DomainService.Operations;
using Host.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [ApiController]
    [Route("e-commerce/orders")]
    public class OrdersController : BaseController
    {
        private readonly OrderOperations orderOperations;
        public OrdersController(OrderOperations orderOperations)
        {
            this.orderOperations = orderOperations;
        }

        [HttpGet]
        public ActionResult<SearchOrderResponse> Search([FromQuery] SearchOrderRequest request)
        {
            var orders = orderOperations.Search(request.customerId, request.addressId, request.orderDate, request.orderStatus, request.sortBy, request.sortDirection, request.pageSize, request.pageNumber, out int totalCount);
            SearchOrderResponse response = new SearchOrderResponse();

            foreach (var order in orders)
            {
                response.orders.Add(new SearchOrderResponse.Order()
                {
                    id = order.Id,
                    customerId = order.CustomerId,
                    addressId = order.AddressId,
                    orderDate = order.OrderDate,
                    orderStatus = order.OrderStatus,
                });
            }

            response.totalCount = totalCount;
            return new JsonResult(response);
        }

        [HttpGet("{id}")]
        public ActionResult<GetSingleOrderResponse> GetSingle(int id)
        {
            var orders = orderOperations.GetSingle(id);
            GetSingleOrderResponse response = new GetSingleOrderResponse();

            response.customerId = orders.CustomerId;
            response.addressId = orders.AddressId;
            response.id = orders.Id;
            response.orderStatus = orders.OrderStatus;
            response.orderDate = orders.OrderDate;

            return new JsonResult(response);
        }

        [HttpPost]
        public void Create([FromBody] CreateOrderRequest request)
        {
            ValidateRequest<CreateOrderRequest, CreateOrderRequestValidator>(request);
            orderOperations.Create(request.customerId, request.addressId, request.orderDate, request.orderStatus);
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] UpdateOrderRequest request)
        {
            ValidateRequest<UpdateOrderRequest, UpdateCustomerRequestValidator>(request);
            orderOperations.Update(id, request.customerId, request.addressId, request.orderDate, request.orderStatus);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            orderOperations.Delete(id);
        }
    }
}
