using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace MicroShop.Core.Domain.Messages
{
    public interface IQuery<T>: IRequest<T>
    {
    }
}
