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
    public class CustomerAddressOperations
    {
        private readonly MainDbContext mainDbContext;
        public CustomerAddressOperations(MainDbContext mainDbContext)
        {
            this.mainDbContext = mainDbContext;
        }
        public IList<CustomerAddress> Search(string streetAddress, string streetAdress2, string city, string zipPostalCode, string phoneNumber, string sortBy, string sortDirection, int pageSize, int pageNumber, out int totalCount)
        {
            var query = mainDbContext.CustomerAddresses.AsQueryable();

            if (!string.IsNullOrEmpty(streetAddress))
                query = query.Where(x => x.StreetAddress == streetAddress);

            if (!string.IsNullOrEmpty(streetAdress2))
                query = query.Where(x => x.StreetAddress2 == streetAdress2);

            if (!string.IsNullOrEmpty(city))
                query = query.Where(x => x.City == city);

            if (!string.IsNullOrEmpty(zipPostalCode))
                query = query.Where(x => x.ZipPostalCode == zipPostalCode);

            if (!string.IsNullOrEmpty(phoneNumber))
                query = query.Where(x => x.PhoneNumber == phoneNumber);

            return query.GetPagedAndSorted(pageNumber, pageSize, sortDirection, sortBy, out totalCount);
        }

        public CustomerAddress GetSingle(int id)
        {
            var customerAdresses = mainDbContext.CustomerAddresses.Where(x => x.Id == id).SingleOrDefault();

            if (customerAdresses == null)
                throw new BusinessException(404, "Müşteri adresi bulunamadı.");

            return customerAdresses;
        }

        public void Create(int customerId, string streetAddress, string streetAdress2, string city, string zipPostalCode, string phoneNumber)
        {
            CustomerAddress customerAddress = new CustomerAddress();
            customerAddress.CustomerId = customerId;
            customerAddress.StreetAddress = streetAddress;
            customerAddress.StreetAddress2 = streetAdress2;
            customerAddress.City = city;
            customerAddress.ZipPostalCode = zipPostalCode;
            customerAddress.PhoneNumber = phoneNumber;

            mainDbContext.CustomerAddresses.Add(customerAddress);
            mainDbContext.SaveChanges();
        }

        public void Update(int id, int customerId, string streetAddress, string streetAdress2, string city, string zipPostalCode, string phoneNumber)
        {
            var customerAddresses = mainDbContext.CustomerAddresses.Where(x => x.Id == id).SingleOrDefault();
            if (customerAddresses == null)
                throw new BusinessException(404, "Müşteri adresi bulunamadı.");

            customerAddresses.CustomerId = customerId;
            customerAddresses.StreetAddress = streetAddress;
            customerAddresses.StreetAddress2 = streetAdress2;
            customerAddresses.City = city;
            customerAddresses.ZipPostalCode = zipPostalCode;
            customerAddresses.PhoneNumber = phoneNumber;

            mainDbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var customerAddresses = mainDbContext.CustomerAddresses.Where(x => x.Id == id).SingleOrDefault();
            if (customerAddresses == null)
                throw new BusinessException(404, "Müşteri adresi bulunamadı.");

            mainDbContext.CustomerAddresses.Remove(customerAddresses);
            mainDbContext.SaveChanges();
        }

    }
}
