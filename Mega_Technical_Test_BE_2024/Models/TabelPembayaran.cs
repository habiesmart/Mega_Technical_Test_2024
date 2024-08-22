using System;
using System.Collections.Generic;

namespace Mega_Technical_Test_BE_2024.Models;

public partial class TabelPembayaran
{
    public string NoKontrak { get; set; }

    public DateTime? TglBayar { get; set; }

    public int? JumlahBayar { get; set; }

    public int? KodeCabang { get; set; }

    public string NoKwitansi { get; set; }

    public string KodeMotor { get; set; }
}
