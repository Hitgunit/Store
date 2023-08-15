using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

using Store.Data;
using System.Drawing;

namespace Store.Models
{
    public class ProductAppService : IProductAppService
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository<ProductDetail, int> _productDetailRepository;

        public ProductAppService(IRepository<ProductDetail, int> productDetailRepository)
        {
            _productDetailRepository = productDetailRepository;
        }

     
        public Task<List<ProductDetail>> GetAll()
        {
            var result = new List<ProductDetail>();
            var filterProductDetail = _productDetailRepository.GetAll().Include(e => e.ProdcutId);
            foreach (var mapeo in filterProductDetail)
            {
                var productDetail = new ProductDetail()
                {
                    ProdcutId = mapeo.ProdcutId,
                    Material = mapeo.Material,

                };
                result.Add(productDetail);
            }
            return Task.FromResult(result);
        }


    }
}
