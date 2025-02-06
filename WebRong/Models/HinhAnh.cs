using System;
using System.Collections.Generic;

namespace WebRong.Models;

public partial class HinhAnh
{
    public int IdHinhanh { get; set; }

    public string TenHinhanh { get; set; } = null!;

    public int IdBvTt { get; set; }

    public string? MotaHinhanh { get; set; }

    public virtual BaiViet IdBvTtNavigation { get; set; } = null!;
}
