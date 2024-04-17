using System;
using System.Collections.Generic;

namespace Карина_и_Лера.Models;

public partial class Provider
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int PhoneNumber { get; set; }

    public int Tin { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
