namespace ApiTest.DataModule;

public interface Item
{
	public int id { get; set; }
}

public class Post : Item
{
	public int id { get; set; }
	public int userId { get; set; }
	public string? title { get; set; }
	public string? body { get; set; }
}

public class User: Item
{
	public int id { get; set; }
	public string? name { get; set; }
	public string? username { get; set; }
	public string? email { get; set; }
	public Address? address { get; set; }
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

public class Address
{
	public string? street { get; set; }
	public string? suite { get; set; }
	public string? city { get; set; }
	public string? zipcode { get; set; }
	public Geo? address { get; set; }
}

public class Geo
{
	public string? lat { get; set; }
	public string? lng { get; set; }
}

public class Album : Item
{
	public int id { get; set; }
	public int userId { get; set; }
	public string? title { get; set; }
}
