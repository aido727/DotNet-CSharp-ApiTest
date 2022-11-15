using Microsoft.AspNetCore.Mvc;
using ApiTest.DataModule;
using System.Collections;

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

    [Route("post/{id}")]
    [HttpGet]
    public async Task<ActionResult<Post>> GetPost(int id)
    {
        if(this.authHeaderHandler(this.Request.Headers))
        {
            var result = await _dataModule.GetData<Post>(id);
            return Ok(result.First());
        }
        else
        {
            return StatusCode(501);
        } 
    }

    [Route("post")]
    [HttpPost]
    public async Task<ActionResult<Post>> PostPost([FromBody] Post post)
    {
        if(this.authHeaderHandler(this.Request.Headers))
        {
            return await _dataModule.PostData<Post>(post);
        }
        else
        {
            return StatusCode(501);
        } 
    }

    [Route("post/{id}")]
    [HttpPut]
    public async Task<ActionResult<Post>> PutPost([FromBody] Post post, int id)
    {
        if(this.authHeaderHandler(this.Request.Headers))
        {
            return await _dataModule.PutData<Post>(post, id);
        }
        else
        {
            return StatusCode(501);
        }
    }

    [Route("post/{id}")]
    [HttpDelete]
    public async Task<ActionResult<Boolean>> DeletePost(int id)
    {
        if(this.authHeaderHandler(this.Request.Headers))
        {
            return await _dataModule.DeleteData<Post>(id);
        }
        else
        {
            return StatusCode(501);
        }
    }

    [Route("user/{id}")]
    [HttpGet]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        if(this.authHeaderHandler(this.Request.Headers))
        {
            var result = await _dataModule.GetData<User>(id);
            return result.First();
        }
        else
        {
            return StatusCode(501);
        }
    }

    [Route("user")]
    [HttpPost]
    public async Task<ActionResult<User>> PostUser([FromBody] User user)
    {
        if(this.authHeaderHandler(this.Request.Headers))
        {
            return await _dataModule.PostData<User>(user);
        }
        else
        {
            return StatusCode(501);
        } 
    }

    [Route("user/{id}")]
    [HttpPut]
    public async Task<ActionResult<User>> PutUser([FromBody] User user, int id)
    {
        if(this.authHeaderHandler(this.Request.Headers))
        {
            return await _dataModule.PutData<User>(user, id);
        }
        else
        {
            return StatusCode(501);
        }
    }

    [Route("user/{id}")]
    [HttpDelete]
    public async Task<ActionResult<Boolean>> DeleteUser(int id)
    {
        if(this.authHeaderHandler(this.Request.Headers))
        {
            return await _dataModule.DeleteData<User>(id);
        }
        else
        {
            return StatusCode(501);
        }
    }

    [Route("album/{id}")]
    [HttpGet]
    public async Task<ActionResult<Album>> GetAlbum(int id)
    {
        if(this.authHeaderHandler(this.Request.Headers))
        {
            var result = await _dataModule.GetData<Album>(id);
            return result.First();
        }
        else
        {
            return StatusCode(501);
        }
    }

    [Route("album")]
    [HttpPost]
    public async Task<ActionResult<Album>> PostAlbum([FromBody] Album album)
    {
        if(this.authHeaderHandler(this.Request.Headers))
        {
            return await _dataModule.PostData<Album>(album);
        }
        else
        {
            return StatusCode(501);
        } 
    }

    [Route("album/{id}")]
    [HttpPut]
    public async Task<ActionResult<Album>> PutAlbum([FromBody] Album album, int id)
    {
        if(this.authHeaderHandler(this.Request.Headers))
        {
            return await _dataModule.PutData<Album>(album, id);
        }
        else
        {
            return StatusCode(501);
        }
    }

	[Route("album/{id}")]
	[HttpDelete]
	public async Task<ActionResult<Boolean>> DeleteAlbum(int id)
	{
		if (this.authHeaderHandler(this.Request.Headers))
		{
			return await _dataModule.DeleteData<Album>(id);
		}
		else
		{
			return StatusCode(501);
		}
	}

    [Route("collection")]
    [HttpGet]
    public async Task<ActionResult<List<Collection>>> GetCollection()
    {
        if (this.authHeaderHandler(this.Request.Headers))
		{
			return await _dataModule.GetCollection();
		}
		else
		{
			return StatusCode(501);
		}
    }
}
