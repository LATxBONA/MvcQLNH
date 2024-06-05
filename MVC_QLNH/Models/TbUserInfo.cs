using System;
using System.Collections.Generic;

namespace MVC_QLNH.Models;

public partial class TbUserInfo
{
    public int MaUser { get; set; }

    public string Taikhoan { get; set; } = null!;

    public string TenUser { get; set; } = null!;

    public DateTime? NgaysinhUser { get; set; }

    public int? GioitinhUser { get; set; }

    public int? SdtUser { get; set; }

    public byte[]? AvtUser { get; set; }
}
