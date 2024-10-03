using System;
using System.Collections.Generic;

namespace TradeApp.Entities;

public partial class PickupPoint
{
    public int PickupPointId { get; set; }

    public string PickupPointAddress { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
