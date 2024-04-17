using System;
using System.Collections.Generic;

namespace Карина_и_Лера.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string JobTitle { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public DateTime Data { get; set; }

    public string PlaceOfWork { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<IngredientFromTheApplication> IngredientFromTheApplications { get; set; } = new List<IngredientFromTheApplication>();

    public virtual ICollection<IngredientRequest> IngredientRequests { get; set; } = new List<IngredientRequest>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
