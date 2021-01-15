using Helper;
using Helper.Exceptions;
using Helper.MessageStatusCode;
using Microsoft.AspNetCore.Mvc;
using Service.Categories;
using Service.Categories.Get;
using Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BETemplateBase.Controllers.Category
{
    [ApiController]
    [Route("Category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public IList<GetCategoryResponse> categories;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetCategoriessAsync()
        {
            try
            {
                var listCategories = await _categoryService.GetCategoryAsync();

                categories = GetCategoryResponse.FromList(listCategories);

            }
            catch (GenericException ex)
            {
                var details = ProblemDetailsCustom.GetProblemDetails("url", "Categories", 400, 
                                                                     MessageGeneral.CategoryDontExist, "");

                return new ObjectResult(details)
                {
                    ContentTypes = { "application/problem+json" },
                    StatusCode = 400,
                };
            }

            return Ok(categories);
        }

    }
}
