using System;
using System.Collections.Generic;

namespace Mega_Technical_Test_BE_2024.Models;

public partial class MsStorageLocation
{
    public string LocationId { get; set; }

    public string LocationName { get; set; }

    public virtual ICollection<TrBpkb> TrBpkbs { get; set; } = new List<TrBpkb>();
}
