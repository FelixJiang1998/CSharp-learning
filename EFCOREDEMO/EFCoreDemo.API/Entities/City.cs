using System;
using System.Collections.Generic;

namespace EFCoreDemo.API.Entities;

public partial class City
{
    public int Id { get; set; }

    public string? CityName { get; set; }

    public int? AdministrativeLevel { get; set; }
}
