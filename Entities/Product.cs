using System;
using System.Collections.Generic;

namespace TradeApp.Entities;

public partial class Product
{
    public string ProductArticleNumber { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public string ProductDescription { get; set; } = null!;

    public byte[]? ProductPhoto { get; set; }

    public decimal ProductCost { get; set; }

    public int? ProductDiscountAmount { get; set; }

    public int? ProductMaxDiscountAmount { get; set; }

    public int ProductQuantityInStock { get; set; }

    public string ProductStatus { get; set; } = null!;

    public int? ProductMeasureUnit { get; set; }

    public int? ProductManufacturer { get; set; }

    public int? ProductProvider { get; set; }

    public int? ProductCategory { get; set; }

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    public virtual Category? ProductCategoryNavigation { get; set; }

    public virtual Manufacturer? ProductManufacturerNavigation { get; set; }

    public virtual MeasureUnit? ProductMeasureUnitNavigation { get; set; }

    public virtual Provider? ProductProviderNavigation { get; set; }
}
