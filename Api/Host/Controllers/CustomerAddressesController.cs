using Contract.Request.CustomerAddresses;
using Contract.Request.Customers;
using Contract.Response.Categories;
using Contract.Response.CustomerAddresses;
using DomainService.Operations;
using Host.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [ApiController]
    [Route("ecommerce-api/customerAddresses")]
    public class CustomerAddressesController : BaseController
    {
        private readonly CustomerAddressOperations customerAddressOperations;
        public CustomerAddressesController(CustomerAddressOperations customerAddressOperations)
        {
            this.customerAddressOperations = customerAddressOperations;
        }

        [HttpGet]
        public ActionResult<SearchCustomerAddressesResponse> Search([FromQuery] SearchCustomerAddressesRequest request)
        {
            var customerAddresses = customerAddressOperations.Search(request.streetAddress, request.streetAddress2, request.city, request.zipPostalCode, request.phoneNumber, request.sortBy, request.sortDirection, request.pageSize, request.pageNumber, out int totalCount);
            SearchCustomerAddressesResponse response = new SearchCustomerAddressesResponse();

            foreach (var customerAddress in customerAddresses)
            {
                response.customerAddresses.Add(new SearchCustomerAddressesResponse.CustomerAddresses()
                {
                    id = customerAddress.Id,
                    streetAddress = customerAddress.StreetAddress,
                    streetAddress2 = customerAddress.StreetAddress2,
                    city = customerAddress.City,
                    phoneNumber = customerAddress.PhoneNumber,
                    zipPostalCode = customerAddress.ZipPostalCode,
                });
            }

            response.totalCount = totalCount;
            return new JsonResult(response);
        }

        [HttpGet("{id}")]
        public ActionResult<GetSingleCustomerAddressesResponse> GetSingle(int id)
        {
            var customerAddress = customerAddressOperations.GetSingle(id);
            GetSingleCustomerAddressesResponse response = new GetSingleCustomerAddressesResponse();

            response.id = customerAddress.Id;
            response.phoneNumber = customerAddress.PhoneNumber;
            response.zipPostalCode = customerAddress.ZipPostalCode;
            response.city = customerAddress.City;
            response.streetAddress = customerAddress.StreetAddress;
            response.streetAddress2 = customerAddress.StreetAddress2;

            return new JsonResult(response);
        }

        [HttpPost]
        public void Create([FromBody] CreateCustomerAddressesRequest request)
        {
            ValidateRequest<CreateCustomerAddressesRequest, CreateCustomerAddressesRequestValidator>(request);
            customerAddressOperations.Create(request.customerId, request.streetAddress, request.streetAddress2, request.city, request.zipPostalCode, request.phoneNumber);
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] UpdateCustomerAddressesRequest request)
        {
            ValidateRequest<UpdateCustomerAddressesRequest, UpdateCustomerAddressesRequestValidator>(request);
            customerAddressOperations.Update(id,request.customerId,request.streetAddress,request.streetAddress2,request.city,request.zipPostalCode,request.phoneNumber);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            customerAddressOperations.Delete(id);
        }
    }
}
