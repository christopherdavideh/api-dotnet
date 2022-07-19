using Microsoft.AspNetCore.Mvc;
using web_api.Models;
using web_api.Services;

namespace web_api.Controllers;

//[Route("api/[controller]")]
[ApiController]
public class DepartmentsController : ControllerBase
{
    IDepartmentsServices _departmentsServices;

    public DepartmentsController( IDepartmentsServices departmentsServices)
    {
        _departmentsServices = departmentsServices;
    }

    // GET: api/<EnterprisesController>
    [HttpGet]
    [Route("[controller]/getDepartments")]
    public async Task<IActionResult> Get()
    {
        try
        {
            return Ok(await _departmentsServices.Get());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
            
        }
    }

    // POST api/<EnterprisesController>
    [HttpPost]
    [Route("[controller]/saveDepartments")]
    public async Task<IActionResult> Post([FromBody] Departments department)
    {
        try
        {
            await _departmentsServices.Save(department);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT api/<EnterprisesController>/5
    [HttpPut]
    [Route("[controller]/updateDepartments/{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Departments department)
    {
        try
        {
            await _departmentsServices.Update(id, department);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE api/<EnterprisesController>/5
    [HttpDelete]
    [Route("[controller]/deleteDepartments/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _departmentsServices.Delete(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}
