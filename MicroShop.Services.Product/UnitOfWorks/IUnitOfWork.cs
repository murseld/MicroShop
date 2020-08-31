using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroShop.Core.Data;

namespace MicroShop.Services.Product.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository GetRepository();
        int SaveChanges();
    }
}
