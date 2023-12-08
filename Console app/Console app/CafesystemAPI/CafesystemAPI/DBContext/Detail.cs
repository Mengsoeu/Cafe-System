using System;
using System.Collections.Generic;

namespace CafesystemAPI.DBContext;

public partial class Detail
{
    public int Id { get; set; }

    public string Product { get; set; } = null!;

    public int Qty { get; set; }

    public string? Size { get; set; }

    public string? Note { get; set; }

    public double? Total { get; set; }
}
