using PathDev.Core.Model.Base;
using PathDev.Core.Model.Dto.Cart;
using PathDev.Core.Model.Dto.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathDev.Core.Model.Interface.Service.Cart
{
    public interface ICartService
    {
        IServiceApiResult<Model.Redis.Cart.Cart> GetCart();
        IServiceApiResult<Model.Redis.Cart.Cart> AddOrUpdateCart(CartDto cart) ;
    }
}
