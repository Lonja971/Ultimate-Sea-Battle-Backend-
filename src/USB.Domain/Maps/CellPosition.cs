using System;
using System.Collections.Generic;
using System.Text;

namespace USB.Domain.Maps
{
    public readonly record struct CellPosition(
        int X,
        int Y
    );
}
