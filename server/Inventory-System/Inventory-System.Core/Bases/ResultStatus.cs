using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Bases
{
    public enum ResultStatus
    {
        Success,
        Created,
        NotFound,
        ValidationError,
        Unauthorized
    }
}
