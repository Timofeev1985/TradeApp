using System;
using System.Collections.Generic;

namespace TradeApp.Entities;

public partial class OrderProduct
{
    public int OrderProduct1 { get; set; }

    public int OrderId { get; set; }

    public string ProductArticleNumber { get; set; } = null!;

    public int OrderProductCount { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product ProductArticleNumberNavigation { get; set; } = null!;
}
