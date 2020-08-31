using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MicroShop.Core.Data;
using MicroShop.Services.Product.Data;
using MicroShop.Services.Product.Repositories;

namespace MicroShop.Services.Product.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductDbContext _dbContext;
        private IMapper _mapper;
        private IProductRepository _productRepository;
        public UnitOfWork(ProductDbContext dbContext, IMapper mapper, IProductRepository productRepository)
        {
            if (dbContext == null)
                throw new ArgumentNullException("dbContext can not be null.");

            _dbContext = dbContext;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        #region IUnitOfWork Members
        public IBaseRepository GetRepository()
        {
            //return new ProductRepository(_dbContext,_mapper);
            return _productRepository;
        }

        public int SaveChanges()
        {
            try
            {
                // Transaction işlemleri burada ele alınabilir
                // veya Identity Map kurumsal tasarım kalıbı kullanılarak
                // sadece değişen alanları güncellemeyide sağlayabiliriz.
                return _dbContext.SaveChanges();
            }
            catch (Exception exception)
            {
                // Burada DbEntityValidationException hatalarını handle edebiliriz.
                Console.Write(exception.Message);
                throw;
            }


        }
        #endregion

        #region IDisposable Members
        // Burada IUnitOfWork arayüzüne implemente ettiğimiz IDisposable arayüzünün Dispose Patternini implemente ediyoruz.
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }

            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
