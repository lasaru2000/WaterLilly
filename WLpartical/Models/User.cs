using System;
using System.Collections.Generic;

namespace WLpartical.Models;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string? EmailAdress { get; set; }

    public string? JobPosition { get; set; }
}
