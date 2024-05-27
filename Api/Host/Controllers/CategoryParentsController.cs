using Contract.Request.CategoryParent;
using Contract.Response.CategoryParent;
using DomainService.Operations;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [ApiController]
    [Route("e-commerce/categoryParent")]
    public class CategoryParentsController
    {
        private readonly CategoryParentOperations categoryParentOperations;
        public CategoryParentsController(CategoryParentOperations categoryParentOperations)
        {
            this.categoryParentOperations = categoryParentOperations;
        }

        [HttpGet]
        public ActionResult<SearchCategoryParentResponse> Search([FromQuery] SearchCategoryParentRequest request)
        {
            var categoryParents = categoryParentOperations.Search(request.name, request.sortBy, request.sortDirection, request.pageSize, request.pageNumber, out int totalCount);
            SearchCategoryParentResponse response = new SearchCategoryParentResponse();
            foreach (var categoryParent in categoryParents)
            {
                response.categoryParents.Add(new SearchCategoryParentResponse.CategoryParent()
                {
                    id = categoryParent.Id,
                    name = categoryParent.Name,
                });
            }
            response.totalCount = totalCount;
            return new JsonResult(response);
        }

        [HttpGet("{id}")]
        public ActionResult<GetSingleCategoryParentResponse> GetSingle(int id)
        {
            var categoryParents = categoryParentOperations.GetSingle(id);
            GetSingleCategoryParentResponse response = new GetSingleCategoryParentResponse();
            response.id = categoryParents.Id;
            response.name = categoryParents.Name;

            return new JsonResult(response);
        }

        [HttpPost]
        public void Crete([FromBody] CreateCategoryParentRequest request)
        {
            categoryParentOperations.Create(request.name);
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] UpdateCategoryParentRequest request)
        {
            categoryParentOperations.Update(id, request.name);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            categoryParentOperations.Delete(id);
        }
    }
}
