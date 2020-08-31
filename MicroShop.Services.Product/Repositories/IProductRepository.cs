using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroShop.Core.Data;
using MicroShop.Services.Product.Data.Dtos;

namespace MicroShop.Services.Product.Repositories
{
    public interface IProductRepository : IBaseRepository
    {
        Task<ProductDto> GetProductByIdAsync(Guid productId);
        Task<List<ProductDto>> GetProductListAsync();


        Task CreateProductAsync(ProductDto product);
        Task UpdateProductAsync(ProductDto product);
    }
}
