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
    public class ProductCommentOperations
    {
        private readonly MainDbContext mainDbContext;
        public ProductCommentOperations(MainDbContext mainDbContext)
        {
            this.mainDbContext = mainDbContext;
        }

        public IList<ProductComment> Search(int productId, int customerId, string comment, string sortBy, string sortDirection, int pageSize, int pageNumber, out int totalCount)
        {
            var query = mainDbContext.ProductComments.AsQueryable();

            if (productId != 0 && productId != null)
                query = query.Where(x => x.ProductId == productId);

            if (customerId != 0 && customerId != null)
                query = query.Where(x => x.CustomerId == customerId);

            if (!string.IsNullOrEmpty(comment))
                query = query.Where(x => x.Comment == comment);

            return query.GetPagedAndSorted(pageNumber, pageSize, sortDirection, sortBy, out totalCount);
        }

        public ProductComment GetSingle(int id)
        {
            var productComment = mainDbContext.ProductComments.Where(x => x.Id == id).SingleOrDefault();
            if (productComment == null)
                throw new BusinessException(404, "Aradığınız yorum bulunamadı.");

            return productComment;
        }

        public void Create(int productId, int customerId, string comment)
        {
            #region Validations
            var currentlyProduct = mainDbContext.ProductComments.Where(x => x.ProductId == productId).SingleOrDefault();
            if (currentlyProduct == null)
                throw new BusinessException(400, "Ürün bulunamadı.");

            var currentlyCustomer = mainDbContext.ProductComments.Where(x => x.CustomerId == customerId).SingleOrDefault();
            if (currentlyCustomer == null)
                throw new BusinessException(400, "Müşteri bulunamadı.");
            #endregion

            ProductComment productComment = new ProductComment();
            productComment.CustomerId = customerId;
            productComment.Comment = comment;
            productComment.ProductId = productId;

            mainDbContext.ProductComments.Add(productComment);
            mainDbContext.SaveChanges();
        }

        public void Update(int id, int productId, int customerId, string comment)
        {
            #region Validations
            var productComments = mainDbContext.ProductComments.Where(x => x.Id == id).SingleOrDefault();
            if (productComments == null)
                throw new BusinessException(404, "Yorum bulunamadı.");
            #endregion

            productComments.Comment = comment;
            productComments.ProductId = productId;
            productComments.CustomerId = customerId;

            mainDbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            #region Validations
            var productComments = mainDbContext.ProductComments.Where(x => x.Id == id).SingleOrDefault();
            if (productComments == null)
                throw new BusinessException(404, "Yorum bulunamadı.");
            #endregion

            mainDbContext.ProductComments.Remove(productComments);
            mainDbContext.SaveChanges();
        }
    }
}
