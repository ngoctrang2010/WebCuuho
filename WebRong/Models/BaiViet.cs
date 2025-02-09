using System;
using System.Collections.Generic;

namespace WebRong.Models;

public partial class BaiViet
{
    public int IdBaiviet { get; set; }

    public string TenBaiviet { get; set; } = null!;

    public DateTime Ngaytao { get; set; }

    public string Noidung { get; set; } = null!;

    public int? IdDichvu { get; set; }

    public bool IsTintuc { get; set; }

    public string? ImageIndex { get; set; }

    public virtual DichVu? IdDichvuNavigation { get; set; }
}
