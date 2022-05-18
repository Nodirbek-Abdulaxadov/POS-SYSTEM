
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
    public class DepartmentController : ControllerBase
    {

        private readonly IDepartmentInterface _departmentInterface;

        public DepartmentController(IDepartmentInterface departmentInterface)
        {
            _departmentInterface = departmentInterface;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var listofDepartments = await _departmentInterface.GetDepartmentsAsync();

            var json = JsonConvert.SerializeObject(listofDepartments, Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });

            return Ok(json);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddDepartment(AddDepartmentViewModel department)
        {
            var res = await _departmentInterface.AddDepartmentAsync((Department)department);
            return Ok(res);


        }

        [HttpPut]


        [Route("update")]
        public async Task<IActionResult> UpdateDepartment(Department department)
        {
            department = await _departmentInterface.UpdateDepartmentAsync(department);
            return Ok(department);
        }

        [HttpDelete, Route("delete/{id}")]
        public async Task<IActionResult> DeleteDepartment(Guid id)
        {
            await _departmentInterface.DeleteDepartmentAsync(id);
            return Ok();
        }

        [HttpGet, Route("get/{id}")]
        public async Task<IActionResult> GetDepartment(Guid id)
        {
            await _departmentInterface.GetDepartmentByIdAsync(id);
            return Ok();
        }

    }
}

