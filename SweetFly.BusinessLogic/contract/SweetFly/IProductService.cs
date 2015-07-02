using SweetFly.Model.Entities;
using SweetFly.Model.Entities.SweetFly;

namespace SweetFly.BusinessLogic.contract
{
    /// <summary>
    /// 产品
    /// </summary>
    public interface IProductService
    {
        Product Insert(Product entity);
    }
}