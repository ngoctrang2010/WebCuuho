using System;
using System.Collections.Generic;

namespace WebRong.Models;

public partial class LienHe
{
    public int IdLienhe { get; set; }

    public string Ten { get; set; } = null!;

    public string Diachi { get; set; } = null!;

    public string Sdt { get; set; } = null!;

    public string Chude { get; set; } = null!;

    public string Noidung { get; set; } = null!;

    public bool Hoanthanh { get; set; }

    public DateTime Ngaytao { get; set; }
}
