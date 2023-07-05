using System;
using System.Collections.Generic;

namespace EFCoreDemo.API.Entities;

public partial class Company
{
    public int Id { get; set; }

    public string? CompanyName { get; set; }

    public string? CompanyNature { get; set; }

    public string? CompanySize { get; set; }
}
