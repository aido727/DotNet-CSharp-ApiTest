using Newtonsoft.Json;

namespace ApiTest.DataModule;

public class DataModuleService
{
	private static List<Post> postsCache = new List<Post>();
	private static List<User> usersCache = new List<User>();
	private static List<Album> albumsCache = new List<Album>();

	const string baseUrl = "https://jsonplaceholder.typicode.com/";

	public static async Task FetchDataAsync(string dataType)
	{
		try
		{
			using (HttpClient client = new HttpClient())
			{
				using (HttpResponseMessage res = await client.GetAsync(baseUrl + dataType))
                {
					res.EnsureSuccessStatusCode();
					
                        using (HttpContent content = res.Content)
                        {
						// if(content is object && content.Headers?.ContentType?.MediaType == "application/json")
						// {
							var data = await content.ReadAsStringAsync();
							if (data != null)
							{
								Console.WriteLine(data);
								switch(dataType)
								{
									case "posts":
										postsCache = JsonConvert.DeserializeObject<List<Post>>(data);
										break;
									case "users":
										usersCache = JsonConvert.DeserializeObject<List<User>>(data);
										break;
									case "albums":
										albumsCache = JsonConvert.DeserializeObject<List<Album>>(data);
										break;
								} 
							}
                        // }
                    }
				}
			}        
		}
		catch(Exception exception)
		{
			Console.WriteLine(exception);
		}
	}

	public async Task<List<Post>> GetPosts()
	{
		// if no cached data available, get it first
		if(postsCache.Count == 0)
		{
			await FetchDataAsync("posts");
		}

		return postsCache;
	}

	public async Task<List<User>> GetUsers()
	{
		// if no cached data available, get it first
		if(postsCache.Count == 0)
		{
			await FetchDataAsync("users");
		}

		return usersCache;
	}

	public async Task<List<Album>> GetAlbums()
	{
		// if no cached data available, get it first
		if(postsCache.Count == 0)
		{
			await FetchDataAsync("albums");
		}

		return albumsCache;
	}
}
