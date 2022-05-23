using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POS_System.Domains.Admin;
using POS_System.Domains.Selling;
using POS_System.Repositories.Interfaces.Identity;
using POS_System.Repositories.Interfaces.Selling;
using POS_System.ViewModels.Admin;
using POS_System.ViewModels.Selling;

namespace POS_System.API.Controllers.Identity
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
    
        private readonly ICategoryInterface _catagoryInterface;

        public CategoryController(ICategoryInterface catagoryInterface)
        {
            _catagoryInterface = catagoryInterface;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var listofCategories = await _catagoryInterface.GetCategoriesAsync();

            var json = JsonConvert.SerializeObject(listofCategories, Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });

            return Ok(json);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddCategory(AddCategoryViewModel category)
        {
            if (await _catagoryInterface.IsNameExist(category.Name))
            {
                return BadRequest($"{category.Name} is already exist!");
            }

            var res = await _catagoryInterface.AddCategoryAsync((Category)category);
            return Ok(res);
        }

        [HttpPut]


        [Route("update")]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            category = await _catagoryInterface.UpdateCategoryAsync(category);
            return Ok(category);
        }

        [HttpDelete, Route("delete/{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            await _catagoryInterface.DeleteCategoryAsync(id);
            return Ok();
        }

        [HttpGet, Route("get/{id}")]
        public async Task<IActionResult> GetCategory(Guid id)
        {
            await _catagoryInterface.GetCategoryAsync(id);
            return Ok();
        }

    }
}

