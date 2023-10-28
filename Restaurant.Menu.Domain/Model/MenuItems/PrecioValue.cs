using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Menu.Domain.Model.MenuItems;

public record PrecioValue : ValueObject
{
    public decimal Value { get; init; }

    public PrecioValue(decimal value)
    {
        if (value < 0)
            throw new BussinessRuleValidationException("El precio no puede ser negativo");

        Value = value;
    }

    public static implicit operator decimal(PrecioValue precio)
    {
        return precio.Value;
    }

    public static implicit operator PrecioValue(decimal precio)
    {
        return new(precio);
    }
}
