using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POS_System.Domains.Admin;
using POS_System.Repositories.Interfaces.Identity;
using POS_System.ViewModels.Admin;

namespace POS_System.API.Controllers.Identity
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminRoleController : ControllerBase
    {
      
        private readonly IAdminRoleInterface _roleInterface;

        public AdminRoleController(IAdminRoleInterface roleInterface)                             
        {
            _roleInterface = roleInterface;
        }
        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var listofadminRoles = await _roleInterface.GetAdminRolesAsync();

            var json = JsonConvert.SerializeObject(listofadminRoles, Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });

            return Ok(json);
        }
        //[HttpPost]
        //[Route("add")]
        //public async Task<IActionResult> AddAdminRole(AddAdminRoleViewModel adminRole)
        //{
        //    var res = await _roleInterface.AddAdminRoleAsync((AdminRole)adminRole);
        //    return Ok(res);
        //}


        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAdminRole(AdminRole adminRole)
        {
            adminRole = await _roleInterface.UpdateAdminRoleAsync(adminRole);
            return Ok(adminRole);
        }

        [HttpDelete, Route("delete/{id}")]
        public async Task<IActionResult> DeleteAdminRole(Guid id)
        {
            await _roleInterface.DeleteAdminRoleAsync(id);
            return Ok();
        }

        [HttpGet, Route("get/{id}")]
        public async Task<IActionResult> GetAdminRole(Guid id)
        {
            await _roleInterface.GetAdminRoleAsync(id);
            return Ok();
        }

    }
}
