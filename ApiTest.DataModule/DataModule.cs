using Newtonsoft.Json;

namespace ApiTest.DataModule;

public class DataModuleService
{
	const string baseUrl = "https://jsonplaceholder.typicode.com/";

	// convert from type to matching external api URL
	private static string GetExternalUrl(string dataType, int id = -1)
	{
		var externalUrl = baseUrl;
		switch(dataType.Substring(dataType.LastIndexOf(".")+1))
		{
			case "Post":
				externalUrl += "posts";
				break;
			case "User":
				externalUrl += "users";
				break;
			case "Album":
				externalUrl += "albums";
				break;
		}

		if(id > -1)
		{
			externalUrl += "/"+id;
		}

		return externalUrl;
	}

	private static async Task<List<T>> FetchDataAsync<T>(int id = -1) // assumption made that negative IDs are not valid
	{
		try
		{
			var externalUrl = GetExternalUrl(typeof(T).ToString(), id);

			using (HttpClient client = new HttpClient())
			{
				using (HttpResponseMessage res = await client.GetAsync(externalUrl))
                {
					// only continue if call to external URL was successful
					res.EnsureSuccessStatusCode();
					
                    using (HttpContent content = res.Content)
                    {
						if(content is object && content.Headers?.ContentType?.MediaType == "application/json")
						{
							var data = await content.ReadAsStringAsync();
							if (data != null)
							{
								if(id > -1)
								{
										return new List<T> {JsonConvert.DeserializeObject<T>(data)};
								}
								else
								{
									return JsonConvert.DeserializeObject<List<T>>(data);
								}
							}
						}
						
						//default handling if no data
						return new List<T>();
                    }
				}
			}        
		}
		catch(Exception exception)
		{
			Console.WriteLine(exception);
			throw;
		}
	}

	private static async Task<T> PostDataAsync<T>(T inputData)
	{
		try
		{
			var externalUrl = GetExternalUrl(typeof(T).ToString());
			using (HttpClient client = new HttpClient())
			{
				StringContent stringContent = new StringContent(JsonConvert.SerializeObject(inputData));
				using (HttpResponseMessage res = await client.PostAsync(externalUrl, stringContent))
                {
					res.EnsureSuccessStatusCode();

                    using (HttpContent content = res.Content)
                    {
						if(content is object && content.Headers?.ContentType?.MediaType == "application/json")
						{
							var data = await content.ReadAsStringAsync();
							if (data != null)
							{
								return JsonConvert.DeserializeObject<T>(data);
							}
						}
						
						return default(T);
                    }
				}
			}
		}
		catch(Exception exception)
		{
			Console.WriteLine(exception);
			throw;
		}
	}

	private static async Task<T> PutDataAsync<T>(T inputData, int id)
	{
		try
		{
			var externalUrl = GetExternalUrl(typeof(T).ToString(), id);
			using (HttpClient client = new HttpClient())
			{
				StringContent stringContent = new StringContent(JsonConvert.SerializeObject(inputData));
				using (HttpResponseMessage res = await client.PutAsync(externalUrl, stringContent))
                {
					res.EnsureSuccessStatusCode();

                    using (HttpContent content = res.Content)
                    {
						if(content is object && content.Headers?.ContentType?.MediaType == "application/json")
						{
							var data = await content.ReadAsStringAsync();
							if (data != null)
							{
								return JsonConvert.DeserializeObject<T>(data);
							}
						}
						
						return default(T);
                    }
				}
			}
		}
		catch(Exception exception)
		{
			Console.WriteLine(exception);
			throw;
		}
	}

	private static async Task<Boolean> DeleteDataAsync<T>(int id)
	{
		try
		{
			var externalUrl = GetExternalUrl(typeof(T).ToString(), id);
			using (HttpClient client = new HttpClient())
			{
				using (HttpResponseMessage res = await client.DeleteAsync(externalUrl))
                {
					res.EnsureSuccessStatusCode();
					return true;
				}
			}			
		}
		catch(Exception exception)
		{
			Console.WriteLine(exception);
			throw;
		}
	}

	public static async Task<List<object>> GetCollectionAsync()
	{
		const int numOfItems = 30;
		try
		{
			List<Item> collection = new List<Item>();
			List<object> result = new List<object>();
			collection.AddRange(await FetchDataAsync<Post>());
			collection.AddRange(await FetchDataAsync<User>());
			collection.AddRange(await FetchDataAsync<Album>());

			var random = new Random();
			// NOTE: there's no guarentee one of each type will appear in the final list

			for(var i = 0; i < numOfItems; i++)
			{
				result.Add(collection[random.Next(collection.Count)]);
			}

			return result;		
		}
		catch(Exception exception)
		{
			Console.WriteLine(exception);
			throw;
		}
	}

	public Task<List<T>> GetData<T>(int id)
	{
		return FetchDataAsync<T>(id);
	}

	public Task<List<T>> GetDataList<T>()
	{
		return FetchDataAsync<T>();
	}

	public Task<T> PostData<T>(T inputData)
	{
		return PostDataAsync<T>(inputData);
	}

	public Task<T> PutData<T>(T inputData, int id)
	{
		return PutDataAsync<T>(inputData, id);
	}

	public Task<Boolean> DeleteData<T>(int id)
	{
		return DeleteDataAsync<T>(id);
	}

	public Task<List<object>> GetCollection()
	{
		return GetCollectionAsync();
	}
}
