using System;
using System.Collections.Generic;

namespace MVCApp.Models;

public partial class Fooditem
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Image { get; set; } = null!;

    public decimal Price { get; set; }
}
