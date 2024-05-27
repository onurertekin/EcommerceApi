using DatabaseModel;
using DatabaseModel.Entities;
using DomainService.Exceptions;
using DomainService.Extensions;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Operations
{
    public class CategoryParentOperations
    {
        private readonly MainDbContext mainDbContext;
        public CategoryParentOperations(MainDbContext mainDbContext)
        {
            this.mainDbContext = mainDbContext;
        }

        public IList<CategoryParent> Search(string name, string sortBy, string sortDirection, int pageSize, int pageNumber, out int totalCount)
        {
            var query = mainDbContext.CategoryParents.AsQueryable();
            if (!string.IsNullOrEmpty(name))
                query = query.Where(x => x.Name == name);

            return query.GetPagedAndSorted(pageNumber, pageSize, sortDirection, sortBy, out totalCount);
        }

        public CategoryParent GetSingle(int id)
        {
            var categoryParent = mainDbContext.CategoryParents.Where(x => x.Id == id).SingleOrDefault();
            if (categoryParent == null)
                throw new BusinessException(404, "Category parent bulunamadı.");
            return categoryParent;
        }
        public void Create(string name)
        {
            var currentlyName = mainDbContext.CategoryParents.Where(x => x.Name == name).SingleOrDefault();
            if (currentlyName != null)
                throw new BusinessException(400, "Bu isimde category parent bulunmaktadır.");

            CategoryParent categoryParent = new CategoryParent();
            categoryParent.Name = name;

            mainDbContext.CategoryParents.Add(categoryParent);
            mainDbContext.SaveChanges();
        }
        public void Update(int id, string name)
        {
            var categoryParent = mainDbContext.CategoryParents.Where(x => x.Id == id).SingleOrDefault();
            if (categoryParent == null)
                throw new BusinessException(404, "Category parent bulunamadı.");
            categoryParent.Name = name;
            mainDbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var categoryParent = mainDbContext.CategoryParents.Where(x => x.Id == id).SingleOrDefault();
            if (categoryParent == null)
                throw new BusinessException(404, "Category parent bulunamadı.");

            mainDbContext.Remove(categoryParent);
            mainDbContext.SaveChanges();
        }
    }
}
