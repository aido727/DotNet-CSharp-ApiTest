namespace ApiTest.DataModule;

public class Post
{
	public int userId { get; set; }
	public int id  { get; set; }
	public string? title { get; set; }
	public string? body { get; set; }
}

public class User
{
	public string? phone { get; set; }
	public string? website { get; set; }
	public Company? company { get; set; }
}

public class Company
{
	public string? name { get; set; }
	public string? catchPhrase { get; set; }
	public string? bs { get; set; }
}

public class Album
{
	public int userId { get; set; }
	public int id { get; set; }
	public string? title { get; set; }
}
