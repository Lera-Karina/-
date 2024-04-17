using System;
using System.Collections.Generic;

namespace Карина_и_Лера.Models;

public partial class ProductsFromOrder
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int OrderId { get; set; }

    public int Quantity { get; set; }

    public float Price { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
