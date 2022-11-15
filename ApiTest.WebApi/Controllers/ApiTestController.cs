using Microsoft.AspNetCore.Mvc;
using ApiTest.DataModule;

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

    [Route("posts")]
    [HttpGet]
    public async Task<List<Post>> GetPosts()
    {
        return await _dataModule.GetPosts();
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
