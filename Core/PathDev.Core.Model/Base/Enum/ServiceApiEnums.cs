using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathDev.Core.Model.Base.Enum
{
    public enum OrderStatusType
    {
        Pending = 1,
        Rejected = 2,
        Preparing = 3,
        ReadyForPickup = 4,
        Delivered = 5,
        CancelledBecauseItWasNotReceived = 6
    }

    public enum PaymentStatusType
    {
        Pending = 1,
        Rejected = 2,
        Paid = 3
    }

}
