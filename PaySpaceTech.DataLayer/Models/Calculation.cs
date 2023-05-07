using System;
using System.Collections.Generic;

namespace PaySpaceTech.DataLayer.Models;

public partial class Calculation
{
    public int Id { get; set; }

    public int PostalCodeId { get; set; }

    public DateTime CreatedDate { get; set; }

    public decimal MonthlyIncome { get; set; }

    public decimal CalculatedValue { get; set; }

    public virtual Postalcode PostalCode { get; set; } = null!;
}
