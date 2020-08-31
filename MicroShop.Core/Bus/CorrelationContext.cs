﻿using System;
using Newtonsoft.Json;

namespace MicroShop.Core.Bus
{
    public interface ICorrelationContext
    {
        Guid CorrelationId { get; }
        Guid CustomerId { get; }
    }

    public class CorrelationContext : ICorrelationContext
    {
        public Guid CorrelationId { get; }
        public Guid CustomerId { get; }

        public CorrelationContext()
        {
        }

        //[JsonConstructor]
        private CorrelationContext(Guid correlationId, Guid customerId)
        {
            CorrelationId = correlationId;
            CustomerId = customerId;
        }

        public static ICorrelationContext Create(Guid id, Guid customerId)
        {
            return new CorrelationContext(id, customerId);
        }
    }
}
