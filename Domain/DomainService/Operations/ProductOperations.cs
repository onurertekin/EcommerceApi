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
    public class ProductOperations
    {
        private readonly MainDbContext mainDbContext;
        public ProductOperations(MainDbContext mainDbContext)
        {
            this.mainDbContext = mainDbContext;
        }

        public IList<Product> Search(string name, string description, decimal? price, int? quantity, string sortBy, string sortDirection, int pageSize, int pageNumber, out int totalCount)
        {
            var query = mainDbContext.Products.AsQueryable();
            if (!string.IsNullOrEmpty(name))
                query = query.Where(x => x.Name == name);

            if (!string.IsNullOrEmpty(description))
                query = query.Where(x => x.Description == description);

            if (price != 0 && price != null)
                query = query.Where((x) => x.Price == price);

            if (quantity != 0 && quantity != null)
                query = query.Where((x) => x.Quantity == quantity);

            return query.GetPagedAndSorted(pageNumber, pageSize, sortDirection, sortBy, out totalCount);
        }

        public Product GetSingle(int id)
        {
            var products = mainDbContext.Products.Where(x => x.Id == id).SingleOrDefault();
            if (products == null)
                throw new BusinessException(404, "Aradığınız ürün bulunamadı.");

            return products;
        }

        public void Create(string name, string description, decimal price, int quantity)
        {
            #region Validation
            var currentlyName = mainDbContext.Products.Where(x => x.Name == name).SingleOrDefault();
            if (currentlyName != null)
                throw new BusinessException(400, "Bu ürün adı kullanılıyor.");
            #endregion

            Product product = new Product();
            product.Name = name;
            product.Description = description;
            product.Price = price;
            product.Quantity = quantity;
            product.CreatedOn = DateTime.Now;

            mainDbContext.Products.Add(product);
            mainDbContext.SaveChanges();
        }

        public void Update(int id, string name, string description, decimal price, int quantity)
        {
            #region Validation
            var products = mainDbContext.Products.Where(x => x.Id == id).SingleOrDefault();
            if (products == null)
                throw new BusinessException(404, "Ürün bulunamadı.");
            #endregion
            products.UpdatedOn = DateTime.Now;
            products.Name = name;
            products.Description = description;
            products.Price = price;
            products.Quantity = quantity;

            mainDbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            #region Validation
            var products = mainDbContext.Products.Where(x => x.Id == id).SingleOrDefault();
            if (products == null)
                throw new BusinessException(404, "Ürün bulunamadı.");
            #endregion

            mainDbContext.Remove(products);
            mainDbContext.SaveChanges();
        }
    }
}
