using System;
using System.Collections.Generic;

namespace Карина_и_Лера.Models;

public partial class Order
{
    public int Id { get; set; }

    public int BuyerId { get; set; }

    public string Status { get; set; } = null!;

    public int EmployeeId { get; set; }

    public virtual Buyer Buyer { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<ProductsFromOrder> ProductsFromOrders { get; set; } = new List<ProductsFromOrder>();
}
