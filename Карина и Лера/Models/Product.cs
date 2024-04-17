using System;
using System.Collections.Generic;

namespace Карина_и_Лера.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public float Price { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<ProductsFromOrder> ProductsFromOrders { get; set; } = new List<ProductsFromOrder>();

    public virtual ICollection<TheIngredientsOfTheGood> TheIngredientsOfTheGoods { get; set; } = new List<TheIngredientsOfTheGood>();
}
