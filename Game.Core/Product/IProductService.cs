using Abp.Domain.Services;
using Game.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Product
{
    public interface IProductService : IEntityDomainService<Product, long>
    {
    }
}
