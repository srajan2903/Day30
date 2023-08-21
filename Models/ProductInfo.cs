using System;
using System.Collections.Generic;

namespace ExerciseDay30.Models;

public partial class ProductInfo
{
    public int Pid { get; set; }

    public string Pname { get; set; } = null!;

    public decimal? Pprice { get; set; }

    public DateTime? Pmdate { get; set; }

    public int? Cid { get; set; }

    public virtual CompanyInfo? CidNavigation { get; set; }
}
