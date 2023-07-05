namespace EFCoreDemo.API.Entities;

public class City
{
    public City()
    {
        // Jobs = new HashSet<Job>();
    }
    public int Id { get; set; }
    public string? CityName { get; set; }
    public int? AdministrativeLevel { get; set; }
    
}