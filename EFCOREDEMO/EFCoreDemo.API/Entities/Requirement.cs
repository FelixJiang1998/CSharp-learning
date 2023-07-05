using System;
using System.Collections.Generic;

namespace EFCoreDemo.API.Entities;

public partial class Requirement
{
    public int Id { get; set; }

    public string? Educations { get; set; }

    public string? Welfares { get; set; }
}
