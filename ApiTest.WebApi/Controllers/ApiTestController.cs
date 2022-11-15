using Microsoft.AspNetCore.Mvc;
using ApiTest.DataModule;
using System.Net;
using System.Net.Http;

namespace ApiTest.WebApi.Controllers;

[ApiController]
[Route("api")]
public class ApiTestController : ControllerBase
{
    private readonly ILogger<ApiTestController> _logger;
    private readonly DataModuleService _dataModule;

    public ApiTestController(ILogger<ApiTestController> logger, DataModuleService dataModule)
    {
        _logger = logger;
        _dataModule = dataModule;
    }

    private Boolean authHeaderHandler(IHeaderDictionary headers)
    {
        if(headers.ContainsKey("Authorization") && headers["Authorization"][0].StartsWith("Bearer "))
        {
            var token = headers["Authorization"][0].Substring("Bearer ".Length);

            return token == "af24353tdsfw";
        }
        return false;
    }

    [Route("posts")]
    [HttpGet]
    public async Task<ActionResult<List<Post>>> GetPostsAsync()
    {
        if(this.authHeaderHandler(this.Request.Headers))
        {
            return await _dataModule.GetPosts();
        }
        else
        {
            return StatusCode(501);
        }
        
    }

    [Route("users")]
    [HttpGet]
    public async Task<List<User>> GetUsers()
    {
        return await _dataModule.GetUsers();
    }

    [Route("albums")]
    [HttpGet]
    public async Task<List<Album>> GetAlbums()
    {
        return await _dataModule.GetAlbums();
    }
}
