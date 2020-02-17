using System;
using System.Collections.Generic;
using System.Text;

using TinyCrm.Core.Model;
using TinyCrm.Core.Model.Options;
using System.Linq;

namespace TinyCrm.Core.Services
{
    public interface IOrderService
    {
        ApiResult<Order> CreateOrder(CreateOrderOptions options);
        public ApiResult<IQueryable<Order>> SearchOrder(
             SearchOrderOptions searchOrderOptions);
    }
}
