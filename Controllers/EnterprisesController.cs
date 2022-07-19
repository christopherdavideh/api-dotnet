using Microsoft.AspNetCore.Mvc;
using web_api.Models;
using web_api.Services;

namespace web_api.Controllers;

//[Route("api/[controller]")]
[ApiController]
public class EnterprisesController : ControllerBase
{
    IEnterprisesServices _enterprisesServices;

    public EnterprisesController( IEnterprisesServices enterprisesServices)
    {
        _enterprisesServices = enterprisesServices;
    }

    // GET: api/<EnterprisesController>
    [HttpGet]
    [Route("[controller]/getEnterprises")]
    public async Task<IActionResult> Get()
    {
        try
        {
            return Ok(await _enterprisesServices.Get());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
            
        }
    }

    // POST api/<EnterprisesController>
    [HttpPost]
    [Route("[controller]/saveEnterprises")]
    public async Task<IActionResult> Post([FromBody] Enterprises enterprise)
    {
        try
        {
            await _enterprisesServices.Save(enterprise);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT api/<EnterprisesController>/5
    [HttpPut]
    [Route("[controller]/updateEnterprises/{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Enterprises enterprise)
    {
        try
        {
            await _enterprisesServices.Update(id, enterprise);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE api/<EnterprisesController>/5
    [HttpDelete]
    [Route("[controller]/deleteEnterprises/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _enterprisesServices.Delete(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}
