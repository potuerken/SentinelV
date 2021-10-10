using Entities.Models;
using System.Collections.Generic;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(Users user, List<OperationClaims> operationClaims);
    }
}
