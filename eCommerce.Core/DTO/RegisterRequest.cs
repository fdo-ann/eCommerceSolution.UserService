using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace eCommerce.Core.DTO
{
    public record RegisterRequest
    (
        string? Email,
        string? Password,
        string? PersonName,
        GenderOptions Gender
     );
}
