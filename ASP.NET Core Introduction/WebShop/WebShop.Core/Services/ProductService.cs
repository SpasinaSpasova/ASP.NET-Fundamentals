using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WebShop.Core.Contracts;
using WebShop.Core.Data.Models;
using WebShop.Core.Models;
using WebShopDemo.Core.Data.Common;

namespace WebShop.Core.Services
{

    /// <summary>
    /// Manipulates product data
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IConfiguration config;
        /// <summary>
        /// IoC 
        /// </summary>
        /// <param name="_config">Application configuration</param>
        /// 
        private readonly IRepository repo;
        public ProductService(IConfiguration _config, IRepository _repo)
        {
            config = _config;
            repo = _repo;
        }

        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="productDto">Product model</param>
        /// <returns></returns>
        public async Task Add(ProductDto productDto)
        {
            var product = new Product()
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Quantity = productDto.Quantity
            };

            await repo.AddAsync(product);
            await repo.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var product = await repo.All<Product>().FirstOrDefaultAsync(p => p.Id == id);

            if (product!=null)
            {
                product.IsActive = false;

                await repo.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns>List of products</returns>
        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            return await repo.AllReadonly<Product>()
                .Where(p => p.IsActive).Select(p => new ProductDto()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity
                }).ToListAsync();
        }
    }
}
