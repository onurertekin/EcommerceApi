using Contract.Request.Customers;
using Contract.Response.Customers;
using DomainService.Operations;
using Host.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [ApiController]
    [Route("ecommerce-api/customers")]
    public class CustomersController : BaseController
    {
        private readonly CustomerOperations customerOperations;
        public CustomersController(CustomerOperations customerOperations)
        {
            this.customerOperations = customerOperations;
        }

        [HttpGet]
        public ActionResult<SearchCustomersResponse> Search([FromQuery] SearchCustomersRequest request)
        {
            var customers = customerOperations.Search(request.firstName, request.lastName, request.userName, request.password, request.email, request.phoneNumber, request.gender, request.sortBy, request.sortDirection, request.pageSize, request.pageNumber, out int totalCount);
            SearchCustomersResponse response = new SearchCustomersResponse();

            foreach (var customer in customers)
            {
                response.customers.Add(new SearchCustomersResponse.Customers()
                {
                    id = customer.Id,
                    firstName = customer.FirstName,
                    phoneNumber = customer.PhoneNumber,
                    lastName = customer.LastName,
                    userName = customer.UserName,
                    password = customer.Password,
                    email = customer.Email,
                    gender = customer.Gender,
                    CreatedOn = customer.RegistrationDate,
                    isDeleted = customer.IsDeleted,
                    status = (int)customer.Status
                });
            }

            response.totalCount = totalCount;

            return new JsonResult(response);
        }

        [HttpGet("{id}")]
        public ActionResult<GetSingleCustomerResponse> GetSingle(int id)
        {
            var customer = customerOperations.GetSingle(id);
            GetSingleCustomerResponse response = new GetSingleCustomerResponse();
            response.id = customer.Id;
            response.firstName = customer.FirstName;
            response.phoneNumber = customer.PhoneNumber;
            response.lastName = customer.LastName;
            response.userName = customer.UserName;
            response.password = customer.Password;
            response.email = customer.Email;
            response.gender = customer.Gender;
            response.CreatedOn = customer.RegistrationDate;
            response.isDeleted = customer.IsDeleted;
            response.status = (int)customer.Status;

            return new JsonResult(response);
        }

        [HttpPost]
        public void Create([FromBody] CreateCustomerRequest request)
        {
            ValidateRequest<CreateCustomerRequest, CreateCustomerRequestValidator>(request);
            customerOperations.Create(request.firstName, request.lastName, request.userName, request.password, request.email, request.phoneNumber, request.gender);
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] UpdateCustomerRequest request)
        {
            ValidateRequest<UpdateCustomerRequest, UpdateCustomerRequestValidator>(request);
            customerOperations.Update(id, request.firstName, request.lastName, request.userName, request.password, request.email, request.phoneNumber);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            customerOperations.Delete(id);
        }

        [HttpPut("{id}/activate")]
        public void Activate(int id)
        {
            customerOperations.Activate(id);
        }

        [HttpPut("{id}/deactivate")]
        public void Deactivate(int id)
        {
            customerOperations.Deactivate(id);
        }
    }
}
