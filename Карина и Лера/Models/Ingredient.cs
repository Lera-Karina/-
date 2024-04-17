using System;
using System.Collections.Generic;

namespace Карина_и_Лера.Models;

public partial class Ingredient
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Compound { get; set; } = null!;

    public virtual ICollection<IngredientFromInvoice> IngredientFromInvoices { get; set; } = new List<IngredientFromInvoice>();

    public virtual ICollection<IngredientFromTheApplication> IngredientFromTheApplications { get; set; } = new List<IngredientFromTheApplication>();

    public virtual ICollection<TheIngredientsOfTheGood> TheIngredientsOfTheGoods { get; set; } = new List<TheIngredientsOfTheGood>();
}
