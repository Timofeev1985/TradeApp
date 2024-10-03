using System;
using System.Collections.Generic;

namespace TradeApp.Entities;

public partial class MeasureUnit
{
    public int MeasureUnitId { get; set; }

    public string MeasureUnitName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
