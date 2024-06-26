﻿using System;
using System.Collections.Generic;

namespace Карина_и_Лера.Models;

public partial class TheIngredientsOfTheGood
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int IngredientId { get; set; }

    public int Quantity { get; set; }

    public virtual Ingredient Ingredient { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
