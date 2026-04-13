using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.Core.DTO
{
    public class AuthenticationResponse(
        Guid UserID,
        string? Email,
        string? PersonName,
        string? Gender,
        string? Token,
        bool Sucess
    );


}
