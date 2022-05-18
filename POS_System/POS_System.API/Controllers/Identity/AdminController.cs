using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POS_System.Domains.Admin;
using POS_System.Repositories.Interfaces.Identity;
using POS_System.ViewModels.Admin;

namespace POS_System.API.Controllers.Identity
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminInterface _adminInterface;

        public AdminController( IAdminInterface adminInterface)
        {
            _adminInterface = adminInterface;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var listOfAdmins = await _adminInterface.GetAdminsAsync();

            var json = JsonConvert.SerializeObject(listOfAdmins, Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });

            return Ok(json);
        }

        //[HttpPost]
        //[Route("add")]
        //public async Task<IActionResult> AddAdmin(AddAdminViewModel admin)
        //{
        //    var res = await _adminInterface.CreateAdminAsync((Admin)admin);
        //    return Ok(res);
        //}

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAdmin(Admin admin)
        {
            admin = await _adminInterface.UpdateAdminAsync(admin);
            return Ok(admin);
        }

        [HttpDelete, Route("delete/{id}")]
        public async Task<IActionResult> DeleteAdmin(Guid id)
        {
            await _adminInterface.DeleteAsync(id);
            return Ok();
        }

        [HttpGet, Route("get/{id}")]
        public async Task<IActionResult> GetAdmin(Guid id)
        {
            await _adminInterface.GetAdminByIdAsync(id);
            return Ok();
        }

        [HttpGet, Route("checkrole")]
        public async Task<IActionResult> IsInRole(Guid id, string roleName)
        {
            bool res = await _adminInterface.IsInRoleAsync(id, roleName);
            if (res)
            {
                return Ok();
            }

            return Unauthorized();
        }

        [HttpGet, Route("login")]
        public async Task<IActionResult> Login(string phoneNumber, string password)
        {
            var res = await _adminInterface.AuthorizeAsync(phoneNumber, password);
            if (res.Item1.Succeeded)
            {
                Admin admin = await _adminInterface.GetAdminByIdAsync(res.Item2);
                return Ok(admin);
            }

            return Unauthorized();
        }
    }
}
