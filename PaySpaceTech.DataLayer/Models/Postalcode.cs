using System;
using System.Collections.Generic;

namespace PaySpaceTech.DataLayer.Models;

public partial class Postalcode
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string CalculationType { get; set; } = null!;

    public virtual ICollection<Calculation> Calculations { get; set; } = new List<Calculation>();
}
