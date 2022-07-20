using Microsoft.AspNetCore.Mvc;
using web_api.Models;
using web_api.Services;

namespace web_api.Controllers;

//[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    IEmployeesServices _employeesServices;

    public EmployeesController( IEmployeesServices employeesServices)
    {
        _employeesServices = employeesServices;
    }

    // GET: api/<EnterprisesController>
    [HttpGet]
    [Route("[controller]/getEmployees")]
    public async Task<IActionResult> Get()
    {
        try
        {
            return Ok(await _employeesServices.Get());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
            
        }
    }

    // POST api/<EnterprisesController>
    [HttpPost]
    [Route("[controller]/saveEmployees")]
    public async Task<IActionResult> Post([FromBody] Employees employee)
    {
        try
        {
            await _employeesServices.Save(employee);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT api/<EnterprisesController>/5
    [HttpPut]
    [Route("[controller]/updateEmployees/{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Employees employee)
    {
        try
        {
            await _employeesServices.Update(id, employee);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE api/<EnterprisesController>/5
    [HttpPut]
    [Route("[controller]/deleteEmployees/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _employeesServices.Delete(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}
