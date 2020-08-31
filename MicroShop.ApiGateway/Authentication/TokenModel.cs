using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroShop.ApiGateway.Authentication
{
    public class TokenModel
    {
        public Guid CustomerId { get; set; }
        public string Email { get; set; }
    }
}
