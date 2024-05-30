using Contract.Request.ProductImages;
using Contract.Response.ProductImage;
using DomainService.Operations;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [ApiController]
    [Route("ecommerce-api/productImages")]
    public class ProductImagesController
    {
        private readonly ProductImageOperations productImageOperations;

        public ProductImagesController(ProductImageOperations productImageOperations)
        {
            this.productImageOperations = productImageOperations;
        }

        [HttpGet]
        public ActionResult<SearchProductImageResponse> Search([FromQuery] SearchProductImageRequest request)
        {
            var productImages = productImageOperations.Search(request.productId, request.sortBy, request.sortDirection, request.pageSize, request.pageNumber, out int totalCount);

            SearchProductImageResponse response = new SearchProductImageResponse();
            foreach (var productImage in productImages)
            {
                response.productImages.Add(new SearchProductImageResponse.ProductImages()
                {
                    id = productImage.Id,
                    productId = productImage.Id,

                });
            }
            response.totalCount = totalCount;
            return new JsonResult(response);

        }

        [HttpGet("{id}")]
        public ActionResult<GetSingleProductImageResponse> GetSingle(int id)
        {
            var productImages = productImageOperations.GetSingle(id);

            GetSingleProductImageResponse response = new GetSingleProductImageResponse();
            response.id = id;
            response.productId = productImages.Id;
            return new JsonResult(response);
        }

        [HttpPost]
        public void Create([FromBody] CreateProductImageRequest request)
        {
            productImageOperations.Create(request.productId);
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] UpdateProductImageRequest request)
        {
            productImageOperations.Update(id, request.productId);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            productImageOperations.Delete(id);
        }
    }
}
