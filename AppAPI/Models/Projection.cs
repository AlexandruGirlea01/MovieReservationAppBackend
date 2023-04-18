namespace AppAPI.Models;

public class Projection
{
    public int ProjectionId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Genre { get; set; }
    public double Rating { get; set; }

    public Projection(string name, string description, string genre, double rating)
    {
        Name = name;
        Description = description;
        Genre = genre;
        Rating = rating;
    }
}