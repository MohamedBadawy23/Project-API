using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Entities.Order;

namespace Talabat.Core.Services.Contract
{
    public interface IPaymentService
    {
        // Function Create Or Update Payment Intent
        Task<CustomerBasket?> CreateOrUpdatePaymentIntent(string basketId);
        Task<Order> UpdatePaymentIntentToSuccssedOrFalid(string paymentIntetId, bool flag);
    }
}
