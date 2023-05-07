using System;
using System.Collections.Generic;

namespace PaySpaceTech.DataLayer.Models;

public partial class Bracket
{
    public int Id { get; set; }

    public int PercentageRate { get; set; }

    public long From { get; set; }

    public long To { get; set; }
}
