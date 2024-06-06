using System;
using System.Collections.Generic;

namespace MVC_QLNH.Models;

public partial class TbBillHistory
{
    public int BillId { get; set; }

    public int? TableId { get; set; }

    public int? UserInfoId { get; set; }

    public string? TableName { get; set; }

    public DateOnly BillDate { get; set; }

    public int TotalAmount { get; set; }

    public virtual TbDstable? Table { get; set; }

    public virtual ICollection<TbBillDetail> TbBillDetails { get; set; } = new List<TbBillDetail>();

    public virtual ICollection<TbRevenu> TbRevenus { get; set; } = new List<TbRevenu>();

    public virtual TbUserInfo? UserInfo { get; set; }
}
