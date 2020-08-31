using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MicroShop.Services.Product.Data;
using MicroShop.Services.Product.Data.Dtos;
using Microsoft.EntityFrameworkCore;

namespace MicroShop.Services.Product.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private readonly ProductDbContext _dbContext;
        private readonly IMapper _mapper;
        public ProductRepository(ProductDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ProductDto> GetProductByIdAsync(Guid productId)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<List<ProductDto>> GetProductListAsync()
        {
            var productList = await _dbContext.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(productList);
        }

        public async Task CreateProductAsync(ProductDto productDto)
        {
            var product = _mapper.Map<Data.Entities.Product>(productDto);
            await _dbContext.Products.AddAsync(product);
        }

        public async Task UpdateProductAsync(ProductDto productDto)
        {
            var product = await _dbContext
                .Products
                .FirstOrDefaultAsync(p => 
                    p.ProductId == productDto.ProductId);

            product.Name = productDto.Name;
            product.Price = productDto.Price;
            product.Quantity = productDto.Quantity;
            product.UpdateDate=DateTime.Now;
            _dbContext.Products.Update(product);
        }
    }
}
