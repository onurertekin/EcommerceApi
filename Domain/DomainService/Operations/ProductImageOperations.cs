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
    public class ProductImageOperations
    {
        private readonly MainDbContext mainDbContext;
        public ProductImageOperations(MainDbContext mainDbContext)
        {
            this.mainDbContext = mainDbContext;
        }

        public IList<ProductImage> Search(int productId, string sortBy, string sortDirection, int pageSize, int pageNumber, out int totalCount)
        {
            var query = mainDbContext.ProductImages.AsQueryable();
            if (productId != 0 && productId != null)
                query = query.Where(x => x.ProductId == productId);

            return query.GetPagedAndSorted(pageNumber, pageSize, sortDirection, sortBy, out totalCount);

        }

        public ProductImage GetSingle(int id)
        {
            var productImage = mainDbContext.ProductImages.Where(x => x.Id == id).SingleOrDefault();
            if (productImage == null)
                throw new BusinessException(404, "Resim bulunamadı.");

            return productImage;
        }
        public void Create(int productId)
        {
            ProductImage productImage = new ProductImage();
            productImage.ProductId = productId;
            mainDbContext.ProductImages.Add(productImage);
            mainDbContext.SaveChanges();
        }
        public void Update(int id, int productId)
        {
            var productImage = mainDbContext.ProductImages.Where(x => x.Id == id).SingleOrDefault();
            if (productImage == null)
                throw new BusinessException(404, "Resim bulunamadı.");

            productImage.ProductId = productId;
            mainDbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var productImage = mainDbContext.ProductImages.Where(x => x.Id == id).SingleOrDefault();
            if (productImage == null)
                throw new BusinessException(404, "Resim bulunamadı.");

            mainDbContext.ProductImages.Remove(productImage);
            mainDbContext.SaveChanges();
        }
    }
}
