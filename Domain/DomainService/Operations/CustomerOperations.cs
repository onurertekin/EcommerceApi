using DatabaseModel;
using DatabaseModel.Entities;
using DatabaseModel.Enumerations;
using DomainService.Exceptions;
using DomainService.Extensions;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Operations
{
    public class CustomerOperations
    {
        private readonly MainDbContext mainDbContext;
        public CustomerOperations(MainDbContext mainDbContext)
        {
            this.mainDbContext = mainDbContext;
        }
        public IList<Customer> Search(string firstName, string lastName, string userName, string password, string email, string phoneNumber,string gender, string sortBy, string sortDirection, int pageSize, int pageNumber, out int totalCount)
        {
            var query = mainDbContext.Customers.AsQueryable();

            if (!string.IsNullOrEmpty(firstName))
                query = query.Where(x => x.FirstName == firstName);

            if (!string.IsNullOrEmpty(lastName))
                query = query.Where(x => x.LastName == lastName);

            if (!string.IsNullOrEmpty(userName))
                query = query.Where(x => x.UserName == userName);

            if (!string.IsNullOrEmpty(password))
                query = query.Where(x => x.Password == password);

            if (!string.IsNullOrEmpty(email))
                query = query.Where(x => x.Email == email);

            if (!string.IsNullOrEmpty(phoneNumber))
                query = query.Where(x => x.PhoneNumber == phoneNumber);

            if (!string.IsNullOrEmpty(gender))
                query = query.Where(x => x.Gender == gender);


            return query.GetPagedAndSorted(pageNumber, pageSize, sortDirection, sortBy, out totalCount);
        }

        public Customer GetSingle(int id)
        {
            var customer = mainDbContext.Customers.Where(x => x.Id == id).SingleOrDefault();
            if (customer == null)
                throw new BusinessException(404, "Müşteri bulunamadı.");
            return customer;
        }

        public void Create(string firstName, string lastName, string userName, string password, string email, string phoneNumber,string gender)
        {
            #region Validations

            var currentlyPhone = mainDbContext.Customers.Where(x => x.PhoneNumber == phoneNumber).SingleOrDefault();
            if (currentlyPhone != null)
                throw new BusinessException(400, "Telefon numarası mevcut.");

            var currentlyEmail = mainDbContext.Customers.Where(x => x.Email == email).SingleOrDefault();
            if (currentlyEmail != null)
                throw new BusinessException(400, "Email adresi mevcut.");

            var currentlyUserName = mainDbContext.Customers.Where(x => x.UserName == userName).SingleOrDefault();
            if (currentlyUserName != null)
                throw new BusinessException(400, "Kullanıcı adı mevcut.");

            #endregion

            Customer customer = new Customer();
            customer.FirstName = firstName;
            customer.LastName = lastName;
            customer.UserName = userName;
            customer.Password = password;
            customer.Email = email;
            customer.PhoneNumber = phoneNumber;
            customer.Gender = gender;
            customer.RegistrationDate = DateTime.Now;
            customer.Status = CustomerStatus.Active;
            mainDbContext.Customers.Add(customer);
            mainDbContext.SaveChanges();
        }

        public void Update(int id, string firstName, string lastName, string userName, string password, string email, string phoneNumber)
        {
            #region Validations

            var customer = mainDbContext.Customers.Where(x => x.Id == id).SingleOrDefault();
            if (customer == null)
                throw new BusinessException(404, "Müşteri bulunamadı");

            #endregion

            customer.FirstName = firstName;
            customer.LastName = lastName;
            customer.UserName = userName;
            customer.Password = password;
            customer.Email = email;
            customer.PhoneNumber = phoneNumber;
            mainDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var customer = mainDbContext.Customers.Where(x => x.Id == id).SingleOrDefault();
            if (customer == null)
                throw new BusinessException(404, "Müşteri bulunamadı");

            customer.IsDeleted = true;
            mainDbContext.SaveChanges();

        }

        public void Activate(int id)
        {
            var customer = mainDbContext.Customers.Where(x => x.Id == id).SingleOrDefault();
            if (customer == null)
                throw new BusinessException(404, "Müşteri bulunamadı");

            customer.Status = CustomerStatus.Active;
            mainDbContext.SaveChanges();
        }

        public void Deactivate(int id)
        {
            var customer = mainDbContext.Customers.Where(x => x.Id == id).SingleOrDefault();
            if (customer == null)
                throw new BusinessException(404, "Müşteri bulunamadı");

            customer.Status = CustomerStatus.Passive;
            mainDbContext.SaveChanges();
        }


    }
}
