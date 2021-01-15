using System.Collections.Generic;
using System.Linq;
using Model;

namespace Service.Categories.Get
{
    public class GetCategoryResponse
    {
        public int IdCategory { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public static List<GetCategoryResponse> FromList(List<Category> categoryList)
        {
            return categoryList.Select(x => new GetCategoryResponse()
            {
                IdCategory = x.IdCategory,
                Name = x.CategoryName,
                Description = x.Description
            }).ToList();
        }
    }
}
