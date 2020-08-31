using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroShop.Services.Order.Data.Entities
{
    public enum OrderStatus
    {
        Created = 0,
        Completed = 1,
        Failed = 2
    }
}
