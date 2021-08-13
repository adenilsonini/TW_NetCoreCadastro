using AutoMapper;
using Cadastro.Domain.Entities;
using Cadastro.Domain.Interfaces;
using Cadastro.Infrastructure.Data.Common;
using Cadastro.Interfaces;
using Cadastro.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.Services
{
    public class ProductViewModelService : IProductViewModelService
    {
        protected readonly RegisterContext _dbContext;

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductViewModelService(IProductRepository productRepository, RegisterContext dbContext, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public void Delete(int id)
        {
           _productRepository.Delete(id);
        }

        public ProductViewModel Get(int id)
        {
            IQueryable<Product> products = _dbContext.Products
                 .Where(c => c.Id == id)
                 .Include(d => d.Client);

            return _mapper.Map<ProductViewModel>(products.FirstOrDefault());
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            IQueryable<Product> products = _dbContext.Products
                  .OrderBy(d => d.Id)
                  .Include(d => d.Client);
        
            if (products == null)
                return new ProductViewModel[] { };
           
            return _mapper.Map<IEnumerable<ProductViewModel>>(products.ToList());
        }

        public void Insert(ProductViewModel viewModel)
        {
            var entity = _mapper.Map<Product>(viewModel);

           _productRepository.Insert(entity);
        }

        public void Update(ProductViewModel viewModel)
        {
            var entity = _mapper.Map<Product>(viewModel);

            _productRepository.Update(entity);
        }

     
    }
}
