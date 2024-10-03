using System;
using System.Collections.Generic;

namespace TradeApp.Entities;

public partial class Order
{
    public int OrderId { get; set; }

    public DateOnly OrderDate { get; set; }

    public DateOnly OrderDeliveryDate { get; set; }

    public string OrderStatus { get; set; } = null!;

    public string OrderSecretKey { get; set; } = null!;

    public int? OrderPickupPoint { get; set; }

    public int? OrderClient { get; set; }

    public virtual User? OrderClientNavigation { get; set; }

    public virtual PickupPoint? OrderPickupPointNavigation { get; set; }

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
}
