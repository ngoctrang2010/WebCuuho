using System;
using System.Collections.Generic;

namespace WebRong.Models;

public partial class DichVu
{
    public int IdDichvu { get; set; }

    public string TenDichvu { get; set; } = null!;

    public string? MotaDichvu { get; set; }

    public virtual ICollection<BaiViet> BaiViets { get; set; } = new List<BaiViet>();
}
