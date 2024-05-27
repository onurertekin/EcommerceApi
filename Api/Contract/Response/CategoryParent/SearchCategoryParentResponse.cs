using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Contract.Response.CategoryParent.SearchCategoryParentResponse;

namespace Contract.Response.CategoryParent
{
    public class SearchCategoryParentResponse
    {
        public class CategoryParent
        {
            public int id { get; set; }
            public string name { get; set; }
        }
        public SearchCategoryParentResponse()
        {
            categoryParents = new List<CategoryParent>();
        }
        public List<CategoryParent> categoryParents { get; set; }
        public int totalCount { get; set; }
    }
}
