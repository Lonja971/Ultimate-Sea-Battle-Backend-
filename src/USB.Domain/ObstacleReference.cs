using System;
using System.Collections.Generic;
using System.Text;
using USB.Domain.Enums;

namespace USB.Domain
{
    public readonly record struct ObstacleReference
    (
        ObstacleType Type,
        int? Id = null
    );
}
