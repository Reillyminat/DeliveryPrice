﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceModel
{
    public enum DeliveryStatus
    {
        InitialCheck,
        DrawingUp,
        HandedOverToSupplier,
        Delivering,
        WaitingForCustomer
    }
}
