using System;
using System.Collections.Generic;

namespace Карина_и_Лера.Models;

public partial class IngredientRequest
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public DateTime Data { get; set; }

    public int Quantity { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<IngredientFromTheApplication> IngredientFromTheApplications { get; set; } = new List<IngredientFromTheApplication>();

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
