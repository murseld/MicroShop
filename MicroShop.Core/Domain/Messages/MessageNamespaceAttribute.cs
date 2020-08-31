﻿using System;

namespace MicroShop.Core.Domain.Messages
{
    [Serializable]
    public class MessageNamespaceAttribute : Attribute
    {
        public string Namespace { get; }

        public MessageNamespaceAttribute(string _namespace)
        {
            Namespace = _namespace?.ToLowerInvariant();
        }
    }
}
