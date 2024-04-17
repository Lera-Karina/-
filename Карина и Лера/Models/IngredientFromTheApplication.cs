using System;
using System.Collections.Generic;

namespace Карина_и_Лера.Models;

public partial class IngredientFromTheApplication
{
    public int Id { get; set; }

    public int ApplicationId { get; set; }

    public int IngredienId { get; set; }

    public int EmployeeId { get; set; }

    public virtual IngredientRequest Application { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual Ingredient Ingredien { get; set; } = null!;
}
