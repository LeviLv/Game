using Abp.Domain.Repositories;
using Game.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Product
{
    public class ProductService: EntityDomainService<Product,long>,IProductService
    {
        private readonly IRepository<Product, long> _repository;
        private readonly IRepository<ProductClass, long> _classRepository;

        public ProductService(IRepository<Product, long> Repository
            , IRepository<ProductClass, long> ClassRepository)
            :base(Repository)
        {
            _classRepository = ClassRepository;
        }
    }
}
