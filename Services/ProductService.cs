using Code_First.Contexts;
using Code_First.Models;
using Code_First.RequestModels;
using Microsoft.EntityFrameworkCore;

namespace Code_First.Services
{
    public interface IProductService
    {
        Task CreateProductAsync(ProductRequestModel model);
    }

    public class ProductService : IProductService
    {
        private readonly DatabaseContext _context;

        public ProductService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task CreateProductAsync(ProductRequestModel model)
        {
            var validCategoryIds = await _context.Categories
                .Where(c => model.ProductCategories.Contains(c.CategoryID))
                .Select(c => c.CategoryID)
                .ToListAsync();

            if (validCategoryIds.Count != model.ProductCategories.Count)
            {
                throw new KeyNotFoundException("Category ID is invalid.");
            }
            var product = new Products
            {
                Name = model.ProductName,
                Weight = model.ProductWeight,
                Width = model.ProductWidth,
                Height = model.ProductHeight,
                Depth = model.ProductDepth
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            var productCategories = model.ProductCategories.Select(categoryId => new Products_Categories
            {
                ProductId = product.ProductID,
                CategoryId = categoryId
            }).ToList();

            _context.Products_Categories.AddRange(productCategories);
            await _context.SaveChangesAsync();
        }
    }
}
