using System;
using System.Collections.Generic;

namespace Карина_и_Лера.Models;

public partial class Invoice
{
    public int Id { get; set; }

    public int InvoiceNumber { get; set; }

    public int ProviderId { get; set; }

    public DateTime DateOfDelivery { get; set; }

    public int ApplicationId { get; set; }

    public virtual IngredientRequest Application { get; set; } = null!;

    public virtual ICollection<IngredientFromInvoice> IngredientFromInvoices { get; set; } = new List<IngredientFromInvoice>();

    public virtual Provider Provider { get; set; } = null!;
}
