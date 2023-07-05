namespace EFCoreDemo.API.Entities;

public partial class Job
{
    public int Id { get; set; }
    public string? JobName { get; set; }
    public string? JobPay { get; set; }
    public string? Welfare { get; set; }
    public string? Education { get; set; }
    public string? WorkExperience { get; set; }
    public int CityId { get; set; }
    public string? WorkArea { get; set; }
    public DateTime? PublishTime { get; set; }
}