using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroShop.ApiGateway.Authentication;
using MicroShop.Core.Bus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroShop.ApiGateway.Controllers
{

    public class BaseController : ControllerBase
    {
        protected readonly IBusPublisher BusPublisher;

        public BaseController(IBusPublisher busPublisher)
        {
            BusPublisher = busPublisher;
        }

        protected TokenModel CurrentUser => HttpContext.Items["CurrentCustomer"] as TokenModel;

        protected ICorrelationContext GetContext()
        {
            return GetContext(CurrentUser.CustomerId);
        }

        //This method is only for AllowAnonymus CustomerController
        protected ICorrelationContext GetContext(Guid customerId)
        {
            return CorrelationContext.Create(Guid.NewGuid(), customerId);
        }
    }
}