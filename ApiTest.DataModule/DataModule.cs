using Newtonsoft.Json;

namespace ApiTest.DataModule;

public class DataModuleService
{
	const string baseUrl = "https://jsonplaceholder.typicode.com/";

	public static async Task<List<T>> FetchDataAsync<T>()
	{
		try
		{
			// convert from type to matching external api URL
			var typeUrl = "";
			var typeString = typeof(T).ToString();
			switch(typeString.Substring(typeString.LastIndexOf(".")+1))
			{
				case "Post":
					typeUrl = "posts";
					break;
				case "User":
					typeUrl = "users";
					break;
				case "Album":
					typeUrl = "albums";
					break;
			}

			using (HttpClient client = new HttpClient())
			{
				using (HttpResponseMessage res = await client.GetAsync(baseUrl + typeUrl))
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
								return JsonConvert.DeserializeObject<List<T>>(data);
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

	public Task<List<T>> GetDataList<T>()
	{
		return FetchDataAsync<T>();
	}
}
