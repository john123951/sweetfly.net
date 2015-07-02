using SweetFly.BusinessLogic.contract;
using SweetFly.Model.Entities;
using SweetFly.Model.Entities.SweetFly;
using SweetFly.Repository.contract;

namespace SweetFly.BusinessLogic
{
    public class ProductService : IProductService
    {
        public ISweetFlyRepository<Product> ProductRepository { get; set; }

        public Product Insert(Product entity)
        {
            throw new System.NotImplementedException();
        }
    }
}