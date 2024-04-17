using System;
using System.Collections.Generic;

namespace Карина_и_Лера.Models;

public partial class IngredientFromInvoice
{
    public int Id { get; set; }

    public int InvoiceId { get; set; }

    public int IngredientId { get; set; }

    public int Quantity { get; set; }

    public float Price { get; set; }

    public virtual Ingredient Ingredient { get; set; } = null!;

    public virtual Invoice Invoice { get; set; } = null!;
}
