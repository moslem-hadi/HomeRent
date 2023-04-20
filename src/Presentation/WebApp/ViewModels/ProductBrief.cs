namespace WebApp.ViewModels;

public class ProductBrief
{
    public Guid Id { get; set; }
    public string Title { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public List<string> Pictures { get; set; } = new List<string>();

    public decimal? Rating { get; set; }

    public int? ReviewCount { get; set; }
}
 
public class Property 
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Icon { get; set; }
}