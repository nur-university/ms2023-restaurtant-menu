using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Menu.Domain.Model.MenuSections
{
    public record ItemSection : ValueObject
    {

        public Guid MenuItemId { get; init; }

        public Guid MenuSectionId { get; init; }

        public ItemSection(Guid menuItemId, Guid menuSectionId)
        {
            MenuItemId = menuItemId;
            MenuSectionId = menuSectionId;
        }

    }
}
