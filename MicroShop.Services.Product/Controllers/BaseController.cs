using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroShop.Core.Bus;
using Microsoft.AspNetCore.Mvc;

namespace MicroShop.Services.Product.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IBusPublisher _busPublisher;
        public BaseController(IBusPublisher busPublisher)
        {
            _busPublisher = busPublisher;
        }

        protected TokenModel CurrentUser
        {
            get
            {
                return HttpContext.Items["CurrentCustomer"] != null ?
                    HttpContext.Items["CurrentCustomer"] as TokenModel : null;
            }
        }

        protected ICorrelationContext GetContext()
        {
            return GetContext(CurrentUser?.CustomerId ?? Guid.NewGuid());
        }

        //This method is only for AllowAnonymus CustomerController
        protected ICorrelationContext GetContext(Guid customerId)
        {
            return CorrelationContext.Create(Guid.NewGuid(), customerId);
        }
    }

    public class TokenModel
    {
        public Guid CustomerId { get; set; }
        public string Email { get; set; }
    }
}