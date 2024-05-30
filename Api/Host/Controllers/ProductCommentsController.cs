using Contract.Request.ProductComments;
using Contract.Response.ProductComments;
using DomainService.Operations;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [ApiController]
    [Route("ecommerce-api/productComment")]
    public class ProductCommentsController
    {
        private readonly ProductCommentOperations productCommentOperations;
        public ProductCommentsController(ProductCommentOperations productCommentOperations)
        {
            this.productCommentOperations = productCommentOperations;
        }

        [HttpGet]
        public ActionResult<SearchProductCommentResponse> Search([FromQuery] SearchProductCommentRequest request)
        {
            var productComments = productCommentOperations.Search(request.productId, request.customerId, request.comment, request.sortBy, request.sortDirection, request.pageSize, request.pageNumber, out int totalCount);
            SearchProductCommentResponse response = new SearchProductCommentResponse();
            foreach (var productComment in productComments)
            {
                response.productComments.Add(new SearchProductCommentResponse.ProductComments()
                {
                    comment = productComment.Comment,
                    productId = productComment.ProductId,
                    customerId = productComment.CustomerId,
                    id = productComment.Id,
                });
            }
            response.totalCount = totalCount;
            return new JsonResult(response);
        }

        [HttpGet("{id}")]
        public ActionResult<GetSingleProductCommentResponse> Search(int id)
        {
            var productComments = productCommentOperations.GetSingle(id);

            GetSingleProductCommentResponse response = new GetSingleProductCommentResponse();
            response.id = productComments.Id;
            response.comment = productComments.Comment;
            response.customerId = productComments.CustomerId;
            response.productId = productComments.ProductId;

            return new JsonResult(response);
        }

        [HttpPost()]
        public void Create([FromBody] CreateProductCommentRequest request)
        {
            productCommentOperations.Create(request.productId, request.customerId, request.comment);
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] UpdateProductCommentRequest request)
        {
            productCommentOperations.Update(id, request.productId, request.customerId, request.comment);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            productCommentOperations.Delete(id);
        }

    }
}
