using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        // Product entitysine özel operasyonlar (joın) için kullanılacak.

        List<ProductDetailDto> GetProductDetails();

    }
}
