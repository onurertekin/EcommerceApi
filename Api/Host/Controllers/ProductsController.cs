using Contract.Request.Categories;
using Contract.Request.Products;
using Contract.Response.Products;
using DomainService.Operations;
using Host.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Contract.Request.Products.CreateProductRequest;

namespace Host.Controllers
{
    [ApiController]
    [Route("e-commerce/products")]
    public class ProductsController : BaseController
    {
        private readonly ProductOperations productOperations;
        public ProductsController(ProductOperations productOperations)
        {
            this.productOperations = productOperations;
        }

        [HttpGet]
        public ActionResult<SearchProductResponse> Search([FromQuery] SearchProductRequest request)
        {
            var products = productOperations.Search(request.name, request.description, request.price, request.quantity, request.sortBy, request.sortDirection, request.pageSize, request.pageNumber, out int totalCount);

            SearchProductResponse response = new SearchProductResponse();

            foreach (var product in products)
            {
                response.products.Add(new SearchProductResponse.Products()
                {
                    id = product.Id,
                    name = product.Name,
                    description = product.Description,
                    price = product.Price,
                    quantity = product.Quantity,
                    createdOn = product.CreatedOn,
                    updatedOn = product.UpdatedOn
                });
            }
            response.totalCount = totalCount;
            return new JsonResult(response);
        }

        [HttpGet("{id}")]
        public ActionResult<GetSingleProductResponse> GetSingle(int id)
        {
            var products = productOperations.GetSingle(id);

            GetSingleProductResponse response = new GetSingleProductResponse();
            response.id = products.Id;
            response.name = products.Name;
            response.description = products.Description;
            response.price = products.Price;
            response.quantity = products.Quantity;
            response.createdOn = products.CreatedOn;
            response.updatedOn = products.UpdatedOn;

            return new JsonResult(response);
        }

        [HttpPost]
        public void Create([FromBody] CreateProductRequest request)
        {
            ValidateRequest<CreateProductRequest, CreateProductRequestValidator>(request);
            productOperations.Create(request.name, request.description, request.price, request.quantity);
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] UpdateProductRequest request)
        {
            ValidateRequest<UpdateProductRequest, UpdateProductRequestValidator>(request);
            productOperations.Update(id, request.name, request.description, request.price, request.quantity);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            productOperations.Delete(id);
        }
    }
}
